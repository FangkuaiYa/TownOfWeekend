using AmongUs.Data.Legacy;
using AmongUs.Data.Player;
using HarmonyLib;

namespace TownOfWeekend.RainbowMod;

[HarmonyPatch(typeof(PlayerData), nameof(PlayerData.FileName),
    MethodType.Getter)]
public class SaveManagerPatch
{
    public static void Postfix(ref string __result)
    {
        __result += "_TOW";
    }
}

[HarmonyPatch(typeof(LegacySaveManager),
    nameof(LegacySaveManager.GetPrefsName))]
public class LegacySaveManagerPatch
{
    public static void Postfix(ref string __result)
    {
        __result += "_TOW";
    }
}