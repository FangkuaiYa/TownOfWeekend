using System;
using AmongUs.GameOptions;
using HarmonyLib;
using TownOfWeekend.Roles;

namespace TownOfWeekend.NeutralRoles.PestilenceMod;

[HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
public class PerformKill
{
    public static bool Prefix(KillButton __instance)
    {
        var flag = PlayerControl.LocalPlayer.Is(RoleEnum.Pestilence);
        if (!flag) return true;
        if (PlayerControl.LocalPlayer.Data.IsDead) return false;
        if (!PlayerControl.LocalPlayer.CanMove) return false;
        var role = Role.GetRole<Pestilence>(PlayerControl.LocalPlayer);
        if (role.Player.inVent) return false;
        if (role.KillTimer() != 0) return false;

        if (role.ClosestPlayer == null) return false;
        var distBetweenPlayers = Utils.GetDistBetweenPlayers(PlayerControl.LocalPlayer, role.ClosestPlayer);
        var flag3 = distBetweenPlayers <
                    LegacyGameOptions.KillDistances[GameOptionsManager.Instance.currentNormalGameOptions.KillDistance];
        if (!flag3) return false;
        var interact = Utils.Interact(PlayerControl.LocalPlayer, role.ClosestPlayer, true);
        if (interact[4]) return false;

        if (interact[0])
        {
            role.LastKill = DateTime.UtcNow;
            return false;
        }

        if (interact[1])
        {
            role.LastKill = DateTime.UtcNow;
            role.LastKill = role.LastKill.AddSeconds(CustomGameOptions.ProtectKCReset - CustomGameOptions.PestKillCd);
            return false;
        }

        if (interact[2])
        {
            role.LastKill = DateTime.UtcNow;
            role.LastKill = role.LastKill.AddSeconds(CustomGameOptions.VestKCReset - CustomGameOptions.PestKillCd);
            return false;
        }

        if (interact[3]) return false;

        return false;
    }
}