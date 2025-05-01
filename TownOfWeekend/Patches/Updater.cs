using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using HarmonyLib;
using Reactor.Utilities;
using TMPro;
using TownOfWeekend.Patches;
using Twitch;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace TownOfWeekend;

[HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
public class ModUpdaterButton
{
    private static Sprite TOWUpdateSprite => ResourcesManager.UpdateTOWButton;
    private static Sprite SubmergedUpdateSprite => ResourcesManager.UpdateSubmergedButton;

    private static void Prefix(MainMenuManager __instance)
    {
        //Check if there's a ToW update
        ModUpdater.LaunchUpdater();
        if (ModUpdater.hasTOWUpdate)
        {
            //If there's an update, create and show the update button
            var template = GameObject.Find("ExitGameButton");
            if (template != null)
            {
                var towButton = Object.Instantiate(template, null);
                towButton.transform.localPosition = new Vector3(towButton.transform.localPosition.x,
                    towButton.transform.localPosition.y + 0.6f, towButton.transform.localPosition.z);

                towButton.transform.localScale = new Vector3(0.44f, 0.84f, 1f);

                var passiveTOWButton = towButton.GetComponent<PassiveButton>();
                var towButtonSprite = towButton.transform.GetChild(1).GetComponent<SpriteRenderer>();
                passiveTOWButton.OnClick = new Button.ButtonClickedEvent();

                towButtonSprite.sprite = TOWUpdateSprite;
                towButton.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = TOWUpdateSprite;

                towButton.transform.SetParent(GameObject.Find("RightPanel").transform);
                var pos = towButton.GetComponent<AspectPosition>();
                pos.Alignment = AspectPosition.EdgeAlignments.LeftBottom;
                pos.DistanceFromEdge = new Vector3(1.5f, 1f, 0f);

                //Add onClick event to run the update on button click
                passiveTOWButton.OnClick.AddListener((Action)(() =>
                {
                    ModUpdater.ExecuteUpdate();
                    towButton.SetActive(false);
                }));

                //Set button text
                var text = towButton.transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>();
                __instance.StartCoroutine(Effects.Lerp(0.1f, new Action<float>(p =>
                {
                    text.SetText("");
                    pos.AdjustPosition();
                })));

                //Set popup stuff
                var man = TwitchManager.Instance;
                ModUpdater.InfoPopup = Object.Instantiate(man.TwitchPopup);
                ModUpdater.InfoPopup.TextAreaTMP.fontSize *= 0.7f;
                ModUpdater.InfoPopup.TextAreaTMP.enableAutoSizing = false;
            }
        }

        if (ModUpdater.hasSubmergedUpdate)
        {
            //If there's an update, create and show the update button
            var template = GameObject.Find("ExitGameButton");
            if (template != null)
            {
                var submergedButton = Object.Instantiate(template, null);
                submergedButton.transform.localPosition = new Vector3(submergedButton.transform.localPosition.x,
                    submergedButton.transform.localPosition.y + 1.2f, submergedButton.transform.localPosition.z);

                submergedButton.transform.localScale = new Vector3(0.44f, 0.84f, 1f);

                var passiveSubmergedButton = submergedButton.GetComponent<PassiveButton>();
                var submergedButtonSprite = submergedButton.transform.GetChild(1).GetComponent<SpriteRenderer>();
                passiveSubmergedButton.OnClick = new Button.ButtonClickedEvent();

                submergedButtonSprite.sprite = SubmergedUpdateSprite;
                submergedButton.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = SubmergedUpdateSprite;

                submergedButton.transform.SetParent(GameObject.Find("RightPanel").transform);
                var pos = submergedButton.GetComponent<AspectPosition>();
                pos.Alignment = AspectPosition.EdgeAlignments.LeftBottom;
                pos.DistanceFromEdge = new Vector3(1.5f, 1.5f, 0f);

                //Add onClick event to run the update on button click
                passiveSubmergedButton.OnClick.AddListener((Action)(() =>
                {
                    ModUpdater.ExecuteUpdate("Submerged");
                    submergedButton.SetActive(false);
                }));

                //Set button text
                var text = submergedButton.transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>();
                __instance.StartCoroutine(Effects.Lerp(0.1f, new Action<float>(p =>
                {
                    text.SetText("");
                    pos.AdjustPosition();
                })));

                //Set popup stuff
                var man = TwitchManager.Instance;
                ModUpdater.InfoPopup = Object.Instantiate(man.TwitchPopup);
                ModUpdater.InfoPopup.TextAreaTMP.fontSize *= 0.7f;
                ModUpdater.InfoPopup.TextAreaTMP.enableAutoSizing = false;
            }
        }
    }
}

public class ModUpdater
{
    public static bool running;
    public static bool hasTOWUpdate;
    public static bool hasSubmergedUpdate;
    public static string updateTOWURI;
    public static string updateSubmergedURI;
    private static Task updateTOWTask;
    private static Task updateSubmergedTask;
    public static GenericPopup InfoPopup;

    public static void LaunchUpdater()
    {
        if (running) return;
        running = true;

        checkForUpdate().GetAwaiter().GetResult();

        //Only check of Submerged update if Submerged is already installed
        var codeBase = Assembly.GetExecutingAssembly().Location;
        var uri = new UriBuilder(codeBase);
        var submergedPath = Uri.UnescapeDataString(uri.Path.Replace("TownOfWeekend", "Submerged"));
        if (File.Exists(submergedPath)) checkForUpdate("Submerged").GetAwaiter().GetResult();

        clearOldVersions();
    }

    public static void ExecuteUpdate(string updateType = "TOW")
    {
        var info = "";
        if (updateType == "TOW")
        {
            info = "Updating Town Of Weekend\nPlease wait...";
            InfoPopup.Show(info);
            if (updateTOWTask == null)
            {
                if (updateTOWURI != null)
                    updateTOWTask = downloadUpdate();
                else
                    info = "Unable to auto-update\nPlease update manually";
            }
            else
            {
                info = "Update might already\nbe in progress";
            }
        }
        else if (updateType == "Submerged")
        {
            info = "Updating Submerged\nPlease wait...";
            InfoPopup.Show(info);
            if (updateSubmergedTask == null)
            {
                if (updateSubmergedURI != null)
                    updateSubmergedTask = downloadUpdate("Submerged");
                else
                    info = "Unable to auto-update\nPlease update manually";
            }
            else
            {
                info = "Update might already\nbe in progress";
            }
        }

        InfoPopup.StartCoroutine(Effects.Lerp(0.01f, new Action<float>(p => { setPopupText(info); })));
    }

    public static void clearOldVersions()
    {
        //Removes any old versions (Denoted by the suffix `.old`)
        try
        {
            var d = new DirectoryInfo(Path.GetDirectoryName(Application.dataPath) + @"\BepInEx\plugins");
            var files = d.GetFiles("*.old").Select(x => x.FullName).ToArray();
            foreach (var f in files)
                File.Delete(f);
        }
        catch (Exception e)
        {
            PluginSingleton<TownOfWeekendPlugin>.Instance.Log.LogMessage(
                "Exception occured when clearing old versions:\n" + e);
        }
    }

    public static async Task<bool> checkForUpdate(string updateType = "TOW")
    {
        //Checks the github api for Town Of Weekend tags. Compares current version (from VersionString in TownOfWeekendPlugin.cs) to the latest tag version(on GitHub)
        try
        {
            var githubURI = "";
            if (updateType == "TOW")
                githubURI = "https://api.github.com/repos/eDonnes124/Town-Of-Us-R/releases/latest";
            else if (updateType == "Submerged")
                githubURI = "https://api.github.com/repos/SubmergedAmongUs/Submerged/releases/latest";
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("User-Agent", "TownOfWeekend Updater");
            var response = await http.GetAsync(new Uri(githubURI), HttpCompletionOption.ResponseContentRead);

            if (response.StatusCode != HttpStatusCode.OK || response.Content == null)
            {
                PluginSingleton<TownOfWeekendPlugin>.Instance.Log.LogMessage("Server returned no data: " +
                                                                             response.StatusCode);
                return false;
            }

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<GitHubApiObject>(json);

            var tagname = data.tag_name;
            if (tagname == null) return false; // Something went wrong

            var diff = 0;
            var ver = Version.Parse(tagname.Replace("v", ""));
            if (updateType == "TOW")
            {
                //Check TOW version
                diff = TownOfWeekendPlugin.Version.CompareTo(ver);
                if (diff < 0) // TOW update required
                    hasTOWUpdate = true;
            }
            else if (updateType == "Submerged")
            {
                //account for broken version
                if (SubmergedCompatibility.Version == null)
                {
                    hasSubmergedUpdate = true;
                }
                else
                {
                    diff = SubmergedCompatibility.Version.CompareTo(
                        SemanticVersioning.Version.Parse(tagname.Replace("v", "")));
                    ;
                    if (diff < 0)
                        // Submerged update required
                        hasSubmergedUpdate = true;
                }
            }

            var assets = data.assets;
            if (assets == null)
                return false;

            foreach (var asset in assets)
            {
                if (asset.browser_download_url == null) continue;
                if (asset.browser_download_url.EndsWith(".dll"))
                {
                    if (updateType == "TOW")
                        updateTOWURI = asset.browser_download_url;
                    else if (updateType == "Submerged") updateSubmergedURI = asset.browser_download_url;
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            PluginSingleton<TownOfWeekendPlugin>.Instance.Log.LogMessage(ex);
        }

        return false;
    }

    public static async Task<bool> downloadUpdate(string updateType = "TOW")
    {
        //Downloads the new TownOfWeekendPlugin/Submerged dll from GitHub into the plugins folder
        var downloadDLL = "";
        var info = "";
        if (updateType == "TOW")
        {
            downloadDLL = updateTOWURI;
            info = "Town Of Weekend\nupdated successfully.\nPlease RESTART the game.";
        }
        else if (updateType == "Submerged")
        {
            downloadDLL = updateSubmergedURI;
            info = "Submerged\nupdated successfully.\nPlease RESTART the game.";
        }

        try
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("User-Agent", "TownOfWeekend Updater");
            var response = await http.GetAsync(new Uri(downloadDLL), HttpCompletionOption.ResponseContentRead);
            if (response.StatusCode != HttpStatusCode.OK || response.Content == null)
            {
                PluginSingleton<TownOfWeekendPlugin>.Instance.Log.LogMessage("Server returned no data: " +
                                                                             response.StatusCode);
                return false;
            }

            var codeBase = Assembly.GetExecutingAssembly().Location;
            var uri = new UriBuilder(codeBase);
            var fullname = Uri.UnescapeDataString(uri.Path);
            if (updateType == "Submerged")
                fullname = fullname.Replace("TownOfWeekend",
                    "Submerged"); //TODO A better solution than this to correctly name the dll files
            if (File.Exists(fullname + ".old")) // Clear old file in case it wasnt;
                File.Delete(fullname + ".old");

            File.Move(fullname, fullname + ".old"); // rename current executable to old

            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                using (var fileStream = File.Create(fullname))
                {
                    responseStream.CopyTo(fileStream);
                }
            }

            showPopup(info);
            return true;
        }
        catch (Exception ex)
        {
            PluginSingleton<TownOfWeekendPlugin>.Instance.Log.LogMessage(ex);
        }

        showPopup("Update wasn't successful\nTry again later,\nor update manually.");
        return false;
    }

    private static void showPopup(string message)
    {
        setPopupText(message);
        InfoPopup.gameObject.SetActive(true);
    }

    public static void setPopupText(string message)
    {
        if (InfoPopup == null)
            return;
        if (InfoPopup.TextAreaTMP != null) InfoPopup.TextAreaTMP.text = message;
    }


    private class GitHubApiObject
    {
        [JsonPropertyName("tag_name")] public string tag_name { get; set; }
        [JsonPropertyName("assets")] public GitHubApiAsset[] assets { get; set; }
    }

    private class GitHubApiAsset
    {
        [JsonPropertyName("browser_download_url")]
        public string browser_download_url { get; set; }
    }
}