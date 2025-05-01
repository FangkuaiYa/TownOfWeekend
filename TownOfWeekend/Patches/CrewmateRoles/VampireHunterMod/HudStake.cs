using HarmonyLib;
using InnerNet;
using TMPro;
using TownOfWeekend.Roles;
using UnityEngine;

namespace TownOfWeekend.CrewmateRoles.VampireHunterMod;

[HarmonyPatch(typeof(HudManager))]
public class HudStake
{
    [HarmonyPatch(nameof(HudManager.Update))]
    public static void Postfix(HudManager __instance)
    {
        if (PlayerControl.AllPlayerControls.Count <= 1) return;
        if (PlayerControl.LocalPlayer == null) return;
        if (PlayerControl.LocalPlayer.Data == null) return;
        if (!PlayerControl.LocalPlayer.Is(RoleEnum.VampireHunter)) return;
        var data = PlayerControl.LocalPlayer.Data;
        var isDead = data.IsDead;
        var stakeButton = __instance.KillButton;

        var role = Role.GetRole<VampireHunter>(PlayerControl.LocalPlayer);

        if (role.UsesText == null && role.UsesLeft >= 0)
        {
            role.UsesText = Object.Instantiate(stakeButton.cooldownTimerText, stakeButton.transform);
            role.UsesText.gameObject.SetActive(false);
            role.UsesText.transform.localPosition = new Vector3(
                role.UsesText.transform.localPosition.x + 0.26f,
                role.UsesText.transform.localPosition.y + 0.29f,
                role.UsesText.transform.localPosition.z);
            role.UsesText.transform.localScale = role.UsesText.transform.localScale * 0.65f;
            role.UsesText.alignment = TextAlignmentOptions.Right;
            role.UsesText.fontStyle = FontStyles.Bold;
        }

        if (role.UsesText != null) role.UsesText.text = role.UsesLeft + "";
        stakeButton.gameObject.SetActive(
            (__instance.UseButton.isActiveAndEnabled || __instance.PetButton.isActiveAndEnabled)
            && !MeetingHud.Instance && !PlayerControl.LocalPlayer.Data.IsDead
            && AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Started);
        role.UsesText.gameObject.SetActive(
            (__instance.UseButton.isActiveAndEnabled || __instance.PetButton.isActiveAndEnabled)
            && !MeetingHud.Instance && !PlayerControl.LocalPlayer.Data.IsDead
            && AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Started);
        if (role.ButtonUsable) stakeButton.SetCoolDown(role.StakeTimer(), CustomGameOptions.StakeCd);
        else stakeButton.SetCoolDown(0f, CustomGameOptions.StakeCd);
        if (role.UsesLeft == 0) return;

        Utils.SetTarget(ref role.ClosestPlayer, stakeButton);

        var renderer = stakeButton.graphic;
        if (role.ClosestPlayer != null && role.ButtonUsable)
        {
            renderer.color = Palette.EnabledColor;
            renderer.material.SetFloat("_Desat", 0f);
            role.UsesText.color = Palette.EnabledColor;
            role.UsesText.material.SetFloat("_Desat", 0f);
        }
        else
        {
            renderer.color = Palette.DisabledClear;
            renderer.material.SetFloat("_Desat", 1f);
            role.UsesText.color = Palette.DisabledClear;
            role.UsesText.material.SetFloat("_Desat", 1f);
        }
    }
}