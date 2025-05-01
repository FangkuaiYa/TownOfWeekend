using HarmonyLib;
using InnerNet;
using TMPro;
using UnityEngine;

namespace TownOfWeekend;

[HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
public static class PingTracker_Update
{
    [HarmonyPostfix]
    public static void Postfix(PingTracker __instance)
    {
        var position = __instance.GetComponent<AspectPosition>();
        if (AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Started)
        {
            __instance.text.alignment = TextAlignmentOptions.Top;
            position.Alignment = AspectPosition.EdgeAlignments.Top;
            position.DistanceFromEdge = new Vector3(1.5f, 0.11f, 0);
        }
        else
        {
            position.Alignment = AspectPosition.EdgeAlignments.LeftTop;
            __instance.text.alignment = TextAlignmentOptions.TopLeft;
            position.DistanceFromEdge = new Vector3(0.5f, 0.11f);
        }

        __instance.text.text =
            $"<size=120%>{"other.modName.text".Translate()} v" +
            TownOfWeekendPlugin.VersionString + "</color></size>\n" +
            (!MeetingHud.Instance
                ? $"<size=2>{"other.pingTracker.modby".Translate()} <color=#00FFFF>FangkuaiYa</color></color>\n"
                : "") +
            (AmongUsClient.Instance.GameState != InnerNetClient.GameStates.Started
                ? $"{"other.pingTracker.baseOn".Translate()} TownOfUs v5.0.3\n"
                : "\n") +
            __instance.text.text + "</size>";
    }
}