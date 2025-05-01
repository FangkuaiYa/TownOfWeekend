using HarmonyLib;

namespace TownOfWeekend.Patches;

[HarmonyPatch(typeof(LobbyBehaviour), nameof(LobbyBehaviour.Start))]
internal static class LobbyBehaviourPatch
{
    [HarmonyPostfix]
    public static void Postfix()
    {
        // Fix Grenadier blind in lobby
        HudManager.Instance.FullScreen.gameObject.active = false;
    }
}