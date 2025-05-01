using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BepInEx.Logging;
using Reactor.Utilities;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TownOfWeekend.Patches.CustomHats;

internal static class HatLoader
{
    private const string HAT_DOWNLOAD_URL = "https://dl.fangkuai.fun/ModFiles/TownOfWeekend/TownOfWeekendHats.zip";
    private const string HAT_ROOT_FOLDER = "TownOfHats";
    private static readonly string HAT_FULL_PATH = Path.Combine(Directory.GetCurrentDirectory(), HAT_ROOT_FOLDER);

    internal static bool LoadedHats;
    internal static readonly Dictionary<string, HatViewData> ViewDataCache = new();

    private static ManualLogSource Log => PluginSingleton<TownOfWeekendPlugin>.Instance.Log;

    internal static void LoadHatsRoutine()
    {
        if (LoadedHats || !HatManager.InstanceExists ||
            HatManager.Instance.allHats.Count == 0)
            return;
        LoadedHats = true;
        Coroutines.Start(LoadHats());
    }

    internal static IEnumerator LoadHats()
    {
        if (!Directory.Exists(HAT_FULL_PATH) || !File.Exists(Path.Combine(HAT_FULL_PATH, "metadata.json")))
            yield return DownloadAndExtractHats();

        try
        {
            var hatJson = LoadJson();
            var hatBehaviours = DiscoverHatBehaviours(hatJson);

            var hatData = new List<HatData>();
            hatData.AddRange(DestroyableSingleton<HatManager>.Instance.allHats);
            hatData.ForEach(x => x.StoreName = "Vanilla");

            var originalCount = DestroyableSingleton<HatManager>.Instance.allHats.Count();
            hatBehaviours.Reverse();
            for (var i = 0; i < hatBehaviours.Count; i++)
            {
                hatBehaviours[i].displayOrder = originalCount + i;
                hatData.Add(hatBehaviours[i]);
            }

            DestroyableSingleton<HatManager>.Instance.allHats = hatData.ToArray();
        }
        catch (Exception e)
        {
            Log.LogError($"Loading Hats Error: {e.Message}\n: {e.StackTrace}");
        }
    }

    private static IEnumerator DownloadAndExtractHats()
    {
        var tempZipPath = Path.Combine(Path.GetTempPath(), "TownOfWeekendHats.zip");
        Task downloadTask = null;

        downloadTask = DownloadFileAsync(tempZipPath);

        while (!downloadTask.IsCompleted) yield return null;

        try
        {
            if (downloadTask.IsFaulted)
            {
                if (downloadTask.Exception != null)
                    throw downloadTask.Exception.InnerException;
                throw new Exception("Downliad Error��");
            }

            if (!Directory.Exists(HAT_FULL_PATH))
                Directory.CreateDirectory(HAT_FULL_PATH);

            ZipFile.ExtractToDirectory(tempZipPath, HAT_FULL_PATH, true);
            Log.LogInfo("Hat resource decompression completed");
        }
        catch (Exception e)
        {
            Log.LogError($"Download/decompression failed: {e.Message}");
            yield break;
        }
        finally
        {
            if (File.Exists(tempZipPath))
                File.Delete(tempZipPath);
        }

        yield return null;
    }

    private static async Task DownloadFileAsync(string tempZipPath)
    {
        using (var client = new HttpClient())
        {
            Log.LogInfo("Start Downloading Custom Hats...");
            client.Timeout = TimeSpan.FromSeconds(30);

            using (var response = await client.GetAsync(HAT_DOWNLOAD_URL, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                using (var contentStream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = new FileStream(tempZipPath, FileMode.Create, FileAccess.Write))
                {
                    await contentStream.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                }
            }
        }
    }

    private static HatMetadataJson LoadJson()
    {
        var jsonPath = Path.Combine(HAT_FULL_PATH, "metadata.json");
        var jsonContent = File.ReadAllText(jsonPath);
        return JsonSerializer.Deserialize<HatMetadataJson>(jsonContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip
        });
    }

    private static List<HatData> DiscoverHatBehaviours(HatMetadataJson metadata)
    {
        var hatBehaviours = new List<HatData>();

        foreach (var hatCredit in metadata.Credits)
            try
            {
                var imagePath = Path.Combine(HAT_FULL_PATH, $"{hatCredit.Id}.png");
                if (File.Exists(imagePath))
                {
                    var imageBytes = File.ReadAllBytes(imagePath);
                    var hatBehaviour = GenerateHatBehaviour(hatCredit.Id, imageBytes);
                    hatBehaviour.StoreName = hatCredit.Artist;
                    hatBehaviour.ProductId = hatCredit.Id;
                    hatBehaviour.name = hatCredit.Name;
                    hatBehaviour.Free = true;
                    hatBehaviours.Add(hatBehaviour);
                }
            }
            catch (Exception e)
            {
                Log.LogError($"Loading Hats: {hatCredit.Id} Error: {e.Message}");
            }

        return hatBehaviours;
    }

    private static HatData GenerateHatBehaviour(string s, byte[] mainImg)
    {
        //TODO: Move to Graphics Utils class
        Sprite sprite;
        if (HatCache.hatViewDatas.ContainsKey(s))
        {
            sprite = HatCache.hatViewDatas[s];
        }
        else
        {
            var tex2D = new Texture2D(1, 1, TextureFormat.ARGB32, false);
            ResourcesManager.LoadImage(tex2D, mainImg, false);
            sprite = Sprite.Create(tex2D, new Rect(0.0f, 0.0f, tex2D.width, tex2D.height), new Vector2(0.5f, 0.5f),
                100);
            HatCache.hatViewDatas.Add(s, sprite);
        }

        var hat = ScriptableObject.CreateInstance<HatData>();
        var viewData = ViewDataCache[hat.name] = ScriptableObject.CreateInstance<HatViewData>();

        hat.ChipOffset = new Vector2(-0.1f, 0.35f);
        viewData.MainImage = sprite;
        hat.ViewDataRef = new AssetReference(ViewDataCache[hat.name].Pointer);
        hat.InFront = true;
        hat.NoBounce = true;

        return hat;
    }
}