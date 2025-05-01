using HarmonyLib;

namespace TownOfWeekend.Patches;

[HarmonyPatch(typeof(ExileController), nameof(ExileController.BeginForGameplay))]
[HarmonyPriority(Priority.First)]
internal class ExileControllerPatch
{
    public static ExileController lastExiled;

    public static void Prefix(ExileController __instance)
    {
        lastExiled = __instance;
    }
}