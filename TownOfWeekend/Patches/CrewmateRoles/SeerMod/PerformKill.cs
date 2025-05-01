using System;
using AmongUs.GameOptions;
using HarmonyLib;
using TownOfWeekend.Roles;
using UnityEngine;

namespace TownOfWeekend.CrewmateRoles.SeerMod;

[HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
public class PerformKill
{
    public static bool Prefix(KillButton __instance)
    {
        if (__instance != HudManager.Instance.KillButton) return true;
        var flag = PlayerControl.LocalPlayer.Is(RoleEnum.Seer);
        if (!flag) return true;
        var role = Role.GetRole<Seer>(PlayerControl.LocalPlayer);
        if (!PlayerControl.LocalPlayer.CanMove || role.ClosestPlayer == null) return false;
        var flag2 = role.SeerTimer() == 0f;
        if (!flag2) return false;
        if (!__instance.enabled) return false;
        var maxDistance =
            LegacyGameOptions.KillDistances[GameOptionsManager.Instance.currentNormalGameOptions.KillDistance];
        if (Vector2.Distance(role.ClosestPlayer.GetTruePosition(),
                PlayerControl.LocalPlayer.GetTruePosition()) > maxDistance) return false;
        if (role.ClosestPlayer == null) return false;

        var interact = Utils.Interact(PlayerControl.LocalPlayer, role.ClosestPlayer);
        if (interact[4]) role.Investigated.Add(role.ClosestPlayer.PlayerId);
        if (interact[0])
        {
            role.LastInvestigated = DateTime.UtcNow;
            return false;
        }

        if (interact[1])
        {
            role.LastInvestigated = DateTime.UtcNow;
            role.LastInvestigated =
                role.LastInvestigated.AddSeconds(CustomGameOptions.ProtectKCReset - CustomGameOptions.SeerCd);
            return false;
        }

        if (interact[3]) return false;

        return false;
    }
}