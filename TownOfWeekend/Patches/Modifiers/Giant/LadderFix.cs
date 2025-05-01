using System.Linq;
using HarmonyLib;
using UnityEngine;

namespace TownOfWeekend.Patches.Modifiers.Giant;

[HarmonyPatch]
public static class LadderFix
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(PlayerControl), "SetKinematic")]
    private static bool Prefix(PlayerControl __instance, bool b)
    {
        if (__instance != PlayerControl.LocalPlayer) return true;
        if (!__instance.onLadder) return true;
        if (!__instance.Is(ModifierEnum.Giant)) return true;
        if (b) return true; // Is start of ladder?
        if (GameOptionsManager.Instance?.currentNormalGameOptions?.MapId != 5) return true; // is not fungle?

        var AllLadders = GameObject.FindObjectsOfType<Ladder>();
        var Ladder = AllLadders.OrderBy(x => Vector3.Distance(x.transform.position, __instance.transform.position))
            .ElementAt(0);


        if (!Ladder.IsTop) return true; // Are we at the bottom?

        __instance.NetTransform.RpcSnapTo(__instance.transform.position + new Vector3(0, 0.5f));

        return true;
    }
}