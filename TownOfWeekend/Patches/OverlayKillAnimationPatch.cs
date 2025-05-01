using System.Linq;
using HarmonyLib;

namespace TownOfWeekend.Patches;

[HarmonyPatch(typeof(OverlayKillAnimation), nameof(OverlayKillAnimation.Initialize))]
internal static class OverlayKillAnimationPatch
{
    private static int currentOutfitTypeCache;

    [HarmonyPrefix]
    public static void Prefix(KillOverlayInitData initData)
    {
        var playerControl = PlayerControl.AllPlayerControls.ToArray()
            .FirstOrDefault(p => p.CurrentOutfit == initData.killerOutfit);
        currentOutfitTypeCache = (int)playerControl.CurrentOutfitType;
        playerControl.CurrentOutfitType = PlayerOutfitType.Default;
    }

    [HarmonyPostfix]
    public static void Postfix(KillOverlayInitData initData)
    {
        var playerControl = PlayerControl.AllPlayerControls.ToArray()
            .FirstOrDefault(p => p.CurrentOutfit == initData.killerOutfit);
        playerControl.CurrentOutfitType = (PlayerOutfitType)currentOutfitTypeCache;
    }
}