using System;
using HarmonyLib;
using UnityEngine;

namespace TownOfWeekend;

[HarmonyPriority(Priority.VeryHigh)] // to show this message first, or be overrided if any plugins do
[HarmonyPatch(typeof(VersionShower), nameof(VersionShower.Start))]
public static class VersionShowerUpdate
{
    public static void Postfix(VersionShower __instance)
    {
        var text = __instance.text;
        text.text += $" - {"other.modName.text".Translate()} v" +
                     TownOfWeekendPlugin.VersionString + "</color>";
        text.transform.localPosition += new Vector3(-0.8f, -0.16f, 0f);

        if (GameObject.Find("RightPanel"))
        {
            text.transform.SetParent(GameObject.Find("RightPanel").transform);

            var aspect = text.gameObject.AddComponent<AspectPosition>();
            aspect.Alignment = AspectPosition.EdgeAlignments.Top;
            aspect.DistanceFromEdge = new Vector3(-0.2f, 2.5f, 8f);

            aspect.StartCoroutine(Effects.Lerp(0.1f, new Action<float>(p => { aspect.AdjustPosition(); })));
        }
    }
}