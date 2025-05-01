using System;
using AmongUs.GameOptions;
using HarmonyLib;
using TownOfWeekend.Roles;

namespace TownOfWeekend.NeutralRoles.ArsonistMod;

[HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
public class PerformKill
{
    public static bool Prefix(KillButton __instance)
    {
        var flag = PlayerControl.LocalPlayer.Is(RoleEnum.Arsonist);
        if (!flag) return true;
        if (PlayerControl.LocalPlayer.Data.IsDead) return false;
        if (!PlayerControl.LocalPlayer.CanMove) return false;
        var role = Role.GetRole<Arsonist>(PlayerControl.LocalPlayer);
        if (!__instance.isActiveAndEnabled || __instance.isCoolingDown) return false;

        if (__instance == role.IgniteButton && role.DousedAlive > 0)
        {
            if (role.DouseTimer() == 0 || (role.LastKiller && CustomGameOptions.IgniteCdRemoved))
            {
                if (role.ClosestPlayerIgnite == null) return false;
                var distBetweenPlayers2 =
                    Utils.GetDistBetweenPlayers(PlayerControl.LocalPlayer, role.ClosestPlayerIgnite);
                var flag3 = distBetweenPlayers2 <
                            LegacyGameOptions.KillDistances[
                                GameOptionsManager.Instance.currentNormalGameOptions.KillDistance];
                if (!flag3) return false;
                if (!role.DousedPlayers.Contains(role.ClosestPlayerIgnite.PlayerId)) return false;

                var interact2 = Utils.Interact(PlayerControl.LocalPlayer, role.ClosestPlayerIgnite);
                if (interact2[4]) role.Ignite();
                if (interact2[0])
                {
                    role.LastDoused = DateTime.UtcNow;
                    return false;
                }

                if (interact2[1])
                {
                    role.LastDoused = DateTime.UtcNow;
                    role.LastDoused.AddSeconds(CustomGameOptions.ProtectKCReset - CustomGameOptions.DouseCd);
                    return false;
                }

                if (interact2[3]) return false;

                return false;
            }

            return false;
        }

        if (__instance != HudManager.Instance.KillButton) return true;
        if (role.DousedAlive == CustomGameOptions.MaxDoused) return false;
        if (role.ClosestPlayerDouse == null) return false;
        var distBetweenPlayers = Utils.GetDistBetweenPlayers(PlayerControl.LocalPlayer, role.ClosestPlayerDouse);
        var flag2 = distBetweenPlayers <
                    LegacyGameOptions.KillDistances[GameOptionsManager.Instance.currentNormalGameOptions.KillDistance];
        if (!flag2) return false;
        if (role.DousedPlayers.Contains(role.ClosestPlayerDouse.PlayerId)) return false;
        var interact = Utils.Interact(PlayerControl.LocalPlayer, role.ClosestPlayerDouse);
        if (interact[4]) role.DousedPlayers.Add(role.ClosestPlayerDouse.PlayerId);
        if (interact[0])
        {
            role.LastDoused = DateTime.UtcNow;
            return false;
        }

        if (interact[1])
        {
            role.LastDoused = DateTime.UtcNow;
            role.LastDoused.AddSeconds(CustomGameOptions.ProtectKCReset - CustomGameOptions.DouseCd);
            return false;
        }

        if (interact[3]) return false;

        return false;
    }
}