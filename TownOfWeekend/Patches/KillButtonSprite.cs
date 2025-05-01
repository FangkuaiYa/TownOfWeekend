using AmongUs.GameOptions;
using HarmonyLib;
using InnerNet;
using Rewired;
using TownOfWeekend.Extensions;
using TownOfWeekend.Patches;
using TownOfWeekend.Roles;
using TownOfWeekend.Roles.Modifiers;
using UnityEngine;

namespace TownOfWeekend;

[HarmonyPatch(typeof(KillButton), nameof(KillButton.Start))]
public static class KillButtonAwake
{
    public static void Prefix(KillButton __instance)
    {
        __instance.transform.Find("Text_TMP").gameObject.SetActive(false);
    }
}

[HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
public class KillButtonSprite
{
    private static Sprite Kill;
    private static Sprite Fix => ResourcesManager.EngineerFix;
    private static Sprite Medic => ResourcesManager.MedicSprite;
    private static Sprite Seer => ResourcesManager.SeerSprite;
    private static Sprite Douse => ResourcesManager.DouseSprite;
    private static Sprite Revive => ResourcesManager.ReviveSprite;
    private static Sprite Alert => ResourcesManager.AlertSprite;
    private static Sprite Remember => ResourcesManager.RememberSprite;
    private static Sprite Track => ResourcesManager.TrackSprite;
    private static Sprite Transport => ResourcesManager.TransportSprite;
    private static Sprite Mediate => ResourcesManager.MediateSprite;
    private static Sprite Vest => ResourcesManager.VestSprite;
    private static Sprite Protect => ResourcesManager.ProtectSprite;
    private static Sprite Infect => ResourcesManager.InfectSprite;
    private static Sprite Trap => ResourcesManager.TrapSprite;
    private static Sprite Inspect => ResourcesManager.InspectSprite;
    private static Sprite Swoop => ResourcesManager.SwoopSprite;
    private static Sprite Observe => ResourcesManager.ObserveSprite;
    private static Sprite Bite => ResourcesManager.BiteSprite;
    private static Sprite Stake => ResourcesManager.StakeSprite;
    private static Sprite Confess => ResourcesManager.ConfessSprite;
    private static Sprite Radiate => ResourcesManager.RadiateSprite;
    private static Sprite SheriffKill => ResourcesManager.SheriffKillSprite;


    public static void Postfix(HudManager __instance)
    {
        if (__instance.KillButton == null) return;

        if (!Kill) Kill = __instance.KillButton.graphic.sprite;

        var flag = false;
        if (PlayerControl.LocalPlayer.Is(RoleEnum.Seer) || PlayerControl.LocalPlayer.Is(RoleEnum.CultistSeer))
        {
            __instance.KillButton.graphic.sprite = Seer;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Medic))
        {
            __instance.KillButton.graphic.sprite = Medic;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Arsonist))
        {
            __instance.KillButton.graphic.sprite = Douse;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Altruist))
        {
            __instance.KillButton.graphic.sprite = Revive;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Veteran))
        {
            __instance.KillButton.graphic.sprite = Alert;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Amnesiac))
        {
            __instance.KillButton.graphic.sprite = Remember;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Tracker))
        {
            __instance.KillButton.graphic.sprite = Track;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Transporter))
        {
            __instance.KillButton.graphic.sprite = Transport;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Medium))
        {
            __instance.KillButton.graphic.sprite = Mediate;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Survivor))
        {
            __instance.KillButton.graphic.sprite = Vest;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.GuardianAngel))
        {
            __instance.KillButton.graphic.sprite = Protect;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Plaguebearer))
        {
            __instance.KillButton.graphic.sprite = Infect;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Engineer) && CustomGameOptions.GameMode != GameMode.Cultist)
        {
            __instance.KillButton.graphic.sprite = Fix;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Trapper))
        {
            __instance.KillButton.graphic.sprite = Trap;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Detective))
        {
            __instance.KillButton.graphic.sprite = Inspect;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Chameleon))
        {
            __instance.KillButton.graphic.sprite = Swoop;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Doomsayer))
        {
            __instance.KillButton.graphic.sprite = Observe;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Vampire))
        {
            __instance.KillButton.graphic.sprite = Bite;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.VampireHunter))
        {
            __instance.KillButton.graphic.sprite = Stake;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Oracle))
        {
            __instance.KillButton.graphic.sprite = Confess;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Aurial))
        {
            __instance.KillButton.graphic.sprite = Radiate;
            flag = true;
        }
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Sheriff))
        {
            __instance.KillButton.graphic.sprite = SheriffKill;
            flag = true;
        }
        else
        {
            __instance.KillButton.graphic.sprite = Kill;
            __instance.KillButton.buttonLabelText.gameObject.SetActive(true);
            __instance.KillButton.buttonLabelText.text = "Kill";
            flag = PlayerControl.LocalPlayer.Is(RoleEnum.Pestilence) ||
                   PlayerControl.LocalPlayer.Is(RoleEnum.Werewolf) || PlayerControl.LocalPlayer.Is(RoleEnum.Juggernaut);
        }

        if (!PlayerControl.LocalPlayer.Is(Faction.Impostors) &&
            GameOptionsManager.Instance.CurrentGameOptions.GameMode != GameModes.HideNSeek)
            __instance.KillButton.transform.localPosition = new Vector3(0f, 1f, 0f);
        if (PlayerControl.LocalPlayer.Is(RoleEnum.Engineer) || PlayerControl.LocalPlayer.Is(RoleEnum.Glitch)
                                                            || PlayerControl.LocalPlayer.Is(RoleEnum.Pestilence) ||
                                                            PlayerControl.LocalPlayer.Is(RoleEnum.Juggernaut)
                                                            || PlayerControl.LocalPlayer.Is(RoleEnum.Vampire))
            __instance.ImpostorVentButton.transform.localPosition = new Vector3(-2f, 0f, 0f);
        else if (PlayerControl.LocalPlayer.Is(RoleEnum.Werewolf))
            __instance.ImpostorVentButton.transform.localPosition = new Vector3(-1f, 1f, 0f);

        var KillKey = ReInput.players.GetPlayer(0).GetButtonDown("Kill");
        var controller = ConsoleJoystick.player.GetButtonDown(8);
        if ((KillKey || controller) && __instance.KillButton != null && flag && !PlayerControl.LocalPlayer.Data.IsDead)
            __instance.KillButton.DoClick();

        var role = Role.GetRole(PlayerControl.LocalPlayer);
        var AbilityKey = ReInput.players.GetPlayer(0).GetButtonDown("ToW imp/nk");
        if (role?.ExtraButtons != null && AbilityKey && !PlayerControl.LocalPlayer.Data.IsDead)
            role?.ExtraButtons[0]?.DoClick();

        if (Modifier.GetModifier<ButtonBarry>(PlayerControl.LocalPlayer)?.ButtonUsed == false &&
            ReInput.players.GetPlayer(0).GetButtonDown("ToW bb/disperse/mimic") &&
            !PlayerControl.LocalPlayer.Data.IsDead)
            Modifier.GetModifier<ButtonBarry>(PlayerControl.LocalPlayer).ButtonButton.DoClick();
        else if (Modifier.GetModifier<Disperser>(PlayerControl.LocalPlayer)?.ButtonUsed == false &&
                 ReInput.players.GetPlayer(0).GetButtonDown("ToW bb/disperse/mimic") &&
                 !PlayerControl.LocalPlayer.Data.IsDead)
            Modifier.GetModifier<Disperser>(PlayerControl.LocalPlayer).DisperseButton.DoClick();
    }

    [HarmonyPatch(typeof(AbilityButton), nameof(AbilityButton.Update))]
    private class AbilityButtonUpdatePatch
    {
        private static void Postfix()
        {
            if (AmongUsClient.Instance.GameState != InnerNetClient.GameStates.Started)
            {
                HudManager.Instance.AbilityButton.gameObject.SetActive(false);
                return;
            }

            if (GameOptionsManager.Instance.CurrentGameOptions.GameMode == GameModes.HideNSeek)
            {
                HudManager.Instance.AbilityButton.gameObject.SetActive(!PlayerControl.LocalPlayer.Data.IsImpostor());
                return;
            }

            var ghostRole = false;
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Haunter))
            {
                var haunter = Role.GetRole<Haunter>(PlayerControl.LocalPlayer);
                if (!haunter.Caught) ghostRole = true;
            }
            else if (PlayerControl.LocalPlayer.Is(RoleEnum.Phantom))
            {
                var phantom = Role.GetRole<Phantom>(PlayerControl.LocalPlayer);
                if (!phantom.Caught) ghostRole = true;
            }

            HudManager.Instance.AbilityButton.gameObject.SetActive(!ghostRole && Utils.ShowDeadBodies &&
                                                                   !MeetingHud.Instance);
        }
    }
}