using System;
using AmongUs.GameOptions;
using HarmonyLib;
using TownOfWeekend.Roles;

namespace TownOfWeekend.NeutralRoles.WerewolfMod;

[HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
public class PerformKill
{
    public static bool Prefix(KillButton __instance)
    {
        var flag = PlayerControl.LocalPlayer.Is(RoleEnum.Werewolf);
        if (!flag) return true;
        if (PlayerControl.LocalPlayer.Data.IsDead) return false;
        if (!PlayerControl.LocalPlayer.CanMove) return false;
        var role = Role.GetRole<Werewolf>(PlayerControl.LocalPlayer);
        if (role.Player.inVent) return false;

        if (__instance == role.RampageButton)
        {
            if (role.RampageTimer() != 0) return false;
            if (!__instance.isActiveAndEnabled || __instance.isCoolingDown) return false;

            role.TimeRemaining = CustomGameOptions.RampageDuration;
            role.Rampage();
            return false;
        }

        if (role.KillTimer() != 0) return false;
        if (!role.Rampaged) return false;
        if (__instance != HudManager.Instance.KillButton) return true;
        if (!__instance.isActiveAndEnabled || __instance.isCoolingDown) return false;
        if (role.ClosestPlayer == null) return false;
        var distBetweenPlayers = Utils.GetDistBetweenPlayers(PlayerControl.LocalPlayer, role.ClosestPlayer);
        var flag3 = distBetweenPlayers <
                    LegacyGameOptions.KillDistances[GameOptionsManager.Instance.currentNormalGameOptions.KillDistance];
        if (!flag3) return false;

        var interact = Utils.Interact(PlayerControl.LocalPlayer, role.ClosestPlayer, true);
        if (interact[4]) return false;

        if (interact[0])
        {
            role.LastKilled = DateTime.UtcNow;
            return false;
        }

        if (interact[1])
        {
            role.LastKilled = DateTime.UtcNow;
            role.LastKilled =
                role.LastKilled.AddSeconds(CustomGameOptions.ProtectKCReset - CustomGameOptions.RampageKillCd);
            return false;
        }

        if (interact[2])
        {
            role.LastKilled = DateTime.UtcNow;
            role.LastKilled =
                role.LastKilled.AddSeconds(CustomGameOptions.VestKCReset - CustomGameOptions.RampageKillCd);
            return false;
        }

        if (interact[3]) return false;

        return false;
    }
}