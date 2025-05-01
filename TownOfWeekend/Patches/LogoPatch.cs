using System;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using TownOfWeekend.Patches;
using UnityEngine;

namespace TownOfWeekend;

[HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
public static class LogoPatch
{
    private static Sprite Sprite => ResourcesManager.ToWBanner;

    private static void Postfix(PingTracker __instance)
    {
        var towLogo = new GameObject("bannerLogo_TownOfWeekend");
        towLogo.transform.localScale = new Vector3(0.8f, 0.8f, 1f);

        var renderer = towLogo.AddComponent<SpriteRenderer>();
        renderer.sprite = Sprite;


        var position = towLogo.AddComponent<AspectPosition>();
        position.DistanceFromEdge = new Vector3(-0.2f, 1.5f, 8f);
        position.Alignment = AspectPosition.EdgeAlignments.Top;

        position.StartCoroutine(Effects.Lerp(0.1f, new Action<float>(p => { position.AdjustPosition(); })));


        var scaler = towLogo.AddComponent<AspectScaledAsset>();
        var renderers = new List<SpriteRenderer>();
        renderers.Add(renderer);

        scaler.spritesToScale = renderers;
        scaler.aspectPosition = position;

        towLogo.transform.SetParent(GameObject.Find("RightPanel").transform);
    }
}