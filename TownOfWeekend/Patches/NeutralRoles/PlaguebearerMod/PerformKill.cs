using System;
using AmongUs.GameOptions;
using HarmonyLib;
using TownOfWeekend.Roles;

namespace TownOfWeekend.NeutralRoles.PlaguebearerMod;

[HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
public class PerformKill
{
    public static bool Prefix(KillButton __instance)
    {
        var flag = PlayerControl.LocalPlayer.Is(RoleEnum.Plaguebearer);
        if (!flag) return true;
        if (PlayerControl.LocalPlayer.Data.IsDead) return false;
        if (!PlayerControl.LocalPlayer.CanMove) return false;
        var role = Role.GetRole<Plaguebearer>(PlayerControl.LocalPlayer);
        if (role.InfectTimer() != 0) return false;

        if (role.ClosestPlayer == null) return false;
        if (role.InfectedPlayers.Contains(role.ClosestPlayer.PlayerId)) return false;
        var distBetweenPlayers = Utils.GetDistBetweenPlayers(PlayerControl.LocalPlayer, role.ClosestPlayer);
        var flag3 = distBetweenPlayers <
                    LegacyGameOptions.KillDistances[GameOptionsManager.Instance.currentNormalGameOptions.KillDistance];
        if (!flag3) return false;
        var interact = Utils.Interact(PlayerControl.LocalPlayer, role.ClosestPlayer);
        if (interact[0])
        {
            role.LastInfected = DateTime.UtcNow;
            return false;
        }

        if (interact[1])
        {
            role.LastInfected = DateTime.UtcNow;
            role.LastInfected.AddSeconds(CustomGameOptions.ProtectKCReset - CustomGameOptions.InfectCd);
            return false;
        }

        if (interact[3]) return false;

        return false;
    }
}