using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Il2CppInterop.Runtime.Injection;
using Reactor;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using TownOfWeekend.CustomOption;
using TownOfWeekend.Patches;
using TownOfWeekend.Patches.ScreenEffects;
using TownOfWeekend.RainbowMod;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TownOfWeekend;

[BepInPlugin(Id, "Town Of Weekend", VersionString)]
[BepInDependency(ReactorPlugin.Id)]
[BepInDependency(SubmergedCompatibility.SUBMERGED_GUID, BepInDependency.DependencyFlags.SoftDependency)]
[ReactorModFlags(ModFlags.RequireOnAllClients)]
public class TownOfWeekendPlugin : BasePlugin
{
    public const string Id = "fangkuai.fun.townofweekend";
    public const string VersionString = "0.10.1";
    public static Version Version = Version.Parse(VersionString);

    public static AssetLoader bundledAssets;

    private Harmony _harmony;

    public static Vector3 ButtonPosition { get; private set; } = new(2.6f, 0.7f, -9f);

    public ConfigEntry<string> Ip { get; set; }

    public ConfigEntry<ushort> Port { get; set; }

    public override void Load()
    {
        Language.Load();
        //ReactorCredits.Register<TownOfWeekendPlugin>(ReactorCredits.AlwaysShow); 
        System.Console.WriteLine("000.000.000.000/000000000000000000");

        _harmony = new Harmony(Id);

        Generate.GenerateAll();

        bundledAssets = new AssetLoader();

        ResourcesManager.loadResources();

        PalettePatch.Load();
        ClassInjector.RegisterTypeInIl2Cpp<RainbowBehaviour>();

        // RegisterInIl2CppAttribute.Register();

        Ip = Config.Bind("Custom", "Ipv4 or Hostname", "127.0.0.1");
        Port = Config.Bind("Custom", "Port", (ushort)22023);
        var defaultRegions = ServerManager.DefaultRegions.ToList();
        var ip = Ip.Value;
        if (Uri.CheckHostName(Ip.Value).ToString() == "Dns")
            foreach (var address in Dns.GetHostAddresses(Ip.Value))
            {
                if (address.AddressFamily != AddressFamily.InterNetwork)
                    continue;
                ip = address.ToString();
                break;
            }

        ServerManager.DefaultRegions = defaultRegions.ToArray();

        SceneManager.add_sceneLoaded((Action<Scene, LoadSceneMode>)((scene, loadSceneMode) =>
        {
            try
            {
                ModManager.Instance.ShowModStamp();
            }
            catch
            {
            }
        }));

        _harmony.PatchAll();
        SubmergedCompatibility.Initialize();
    }
}