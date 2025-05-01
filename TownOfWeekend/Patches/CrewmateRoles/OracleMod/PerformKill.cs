using System;
using AmongUs.GameOptions;
using HarmonyLib;
using TownOfWeekend.Roles;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TownOfWeekend.CrewmateRoles.OracleMod;

[HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
public class PerformKill
{
    public static bool Prefix(KillButton __instance)
    {
        if (__instance != HudManager.Instance.KillButton) return true;
        var flag = PlayerControl.LocalPlayer.Is(RoleEnum.Oracle);
        if (!flag) return true;
        var role = Role.GetRole<Oracle>(PlayerControl.LocalPlayer);
        if (!PlayerControl.LocalPlayer.CanMove || role.ClosestPlayer == null) return false;
        var flag2 = role.ConfessTimer() == 0f;
        if (!flag2) return false;
        if (!__instance.enabled) return false;
        var maxDistance =
            LegacyGameOptions.KillDistances[GameOptionsManager.Instance.currentNormalGameOptions.KillDistance];
        if (Vector2.Distance(role.ClosestPlayer.GetTruePosition(),
                PlayerControl.LocalPlayer.GetTruePosition()) > maxDistance) return false;
        if (role.ClosestPlayer == null) return false;

        var interact = Utils.Interact(PlayerControl.LocalPlayer, role.ClosestPlayer);
        if (interact[4])
        {
            role.Confessor = role.ClosestPlayer;
            var showsCorrectFaction = true;
            var faction = 1;
            if (role.Accuracy == 0f)
            {
                showsCorrectFaction = false;
            }
            else
            {
                var num = Random.RandomRangeInt(1, 101);
                showsCorrectFaction = num <= role.Accuracy;
            }

            if (showsCorrectFaction)
            {
                if (role.Confessor.Is(Faction.Crewmates)) faction = 0;
                else if (role.Confessor.Is(Faction.Impostors)) faction = 2;
            }
            else
            {
                var num = Random.RandomRangeInt(0, 2);
                if (role.Confessor.Is(Faction.Impostors)) faction = num;
                else if (role.Confessor.Is(Faction.Crewmates)) faction = num + 1;
                else if (num == 1) faction = 2;
                else faction = 0;
            }

            if (faction == 0) role.RevealedFaction = Faction.Crewmates;
            else if (faction == 1) role.RevealedFaction = Faction.NeutralEvil;
            else role.RevealedFaction = Faction.Impostors;
            Utils.Rpc(CustomRPC.Confess, PlayerControl.LocalPlayer.PlayerId, role.Confessor.PlayerId, faction);
        }

        if (interact[0])
        {
            role.LastConfessed = DateTime.UtcNow;
            return false;
        }

        if (interact[1])
        {
            role.LastConfessed = DateTime.UtcNow;
            role.LastConfessed =
                role.LastConfessed.AddSeconds(CustomGameOptions.ProtectKCReset - CustomGameOptions.ConfessCd);
            return false;
        }

        if (interact[3]) return false;

        return false;
    }
}