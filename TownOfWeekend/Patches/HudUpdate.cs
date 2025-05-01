using System;
using AmongUs.GameOptions;
using HarmonyLib;
using InnerNet;
using TownOfWeekend.Roles;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace TownOfWeekend.Patches;

[HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
public static class HudUpdate
{
    private static GameObject ZoomButton;
    public static bool Zooming;
    private static Vector3 Pos;

    public static void Postfix(HudManager __instance)
    {
        if (!ZoomButton)
        {
            ZoomButton = Object.Instantiate(__instance.MapButton.gameObject, __instance.MapButton.transform.parent);
            ZoomButton.GetComponent<PassiveButton>().OnClick = new Button.ButtonClickedEvent();
            ZoomButton.GetComponent<PassiveButton>().OnClick.AddListener(new Action(Zoom));
            ZoomButton.name = "Zoom";
        }

        Pos = __instance.MapButton.transform.localPosition + new Vector3(0.02f, -0.66f, 0f);
        Pos = __instance.MapButton.transform.localPosition + new Vector3(0f, -0.8f, 0f);
        if (SubmergedCompatibility.Loaded && GameOptionsManager.Instance.currentNormalGameOptions.MapId == 6)
            Pos = __instance.SettingsButton.transform.localPosition + new Vector3(0f, -0.8f, 0f);
        var dead = false;
        if (Utils.ShowDeadBodies)
        {
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Haunter))
            {
                var haunter = Role.GetRole<Haunter>(PlayerControl.LocalPlayer);
                if (haunter.Caught) dead = true;
            }
            else if (PlayerControl.LocalPlayer.Is(RoleEnum.Phantom))
            {
                var phantom = Role.GetRole<Phantom>(PlayerControl.LocalPlayer);
                if (phantom.Caught) dead = true;
            }
            else
            {
                dead = true;
            }
        }

        ZoomButton.SetActive(!MeetingHud.Instance && dead &&
                             AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Started
                             && GameOptionsManager.Instance.CurrentGameOptions.GameMode == GameModes.Normal &&
                             HauntMenuMinigame.Instance == null);
        ZoomButton.transform.localPosition = Pos;
        ZoomButton.transform.Find("Background").localPosition = Vector3.zero;
        ZoomButton.transform.Find("Inactive").GetComponent<SpriteRenderer>().sprite =
            Zooming ? ResourcesManager.ZoomPlusButton : ResourcesManager.ZoomMinusButton;
        ZoomButton.transform.Find("Active").GetComponent<SpriteRenderer>().sprite = Zooming
            ? ResourcesManager.ZoomPlusActiveButton
            : ResourcesManager.ZoomMinusActiveButton;
    }

    public static void Zoom()
    {
        Zooming = !Zooming;
        var size = Zooming ? 12f : 3f;
        Camera.main.orthographicSize = size;

        foreach (var cam in Camera.allCameras)
            if (cam?.gameObject.name == "UI Camera")
                cam.orthographicSize = size;

        ResolutionManager.ResolutionChanged.Invoke((float)Screen.width / Screen.height, Screen.width, Screen.height,
            Screen.fullScreen);
    }

    public static void ZoomStart()
    {
        var size = Zooming ? 12f : 3f;
        Camera.main.orthographicSize = size;

        foreach (var cam in Camera.allCameras)
            if (cam?.gameObject.name == "UI Camera")
                cam.orthographicSize = size;

        ResolutionManager.ResolutionChanged.Invoke((float)Screen.width / Screen.height, Screen.width, Screen.height,
            Screen.fullScreen);
    }
}