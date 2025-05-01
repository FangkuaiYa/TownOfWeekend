using System;
using System.Linq;
using HarmonyLib;
using TownOfWeekend.CrewmateRoles.MedicMod;
using TownOfWeekend.Roles;
using Object = UnityEngine.Object;

namespace TownOfWeekend.CrewmateRoles.MediumMod;

[HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
public class PerformKill
{
    public static bool Prefix(KillButton __instance)
    {
        if (!PlayerControl.LocalPlayer.Is(RoleEnum.Medium)) return true;
        var role = Role.GetRole<Medium>(PlayerControl.LocalPlayer);
        if (!PlayerControl.LocalPlayer.CanMove) return false;
        if (PlayerControl.LocalPlayer.Data.IsDead) return false;
        if (!__instance.enabled) return false;
        if (role.MediateTimer() != 0f) return false;

        role.LastMediated = DateTime.UtcNow;

        var PlayersDead = Murder.KilledPlayers.GetRange(0, Murder.KilledPlayers.Count);
        if (CustomGameOptions.DeadRevealed == DeadRevealed.Newest) PlayersDead.Reverse();
        foreach (var dead in Murder.KilledPlayers)
            if (Object.FindObjectsOfType<DeadBody>().Any(x =>
                    x.ParentId == dead.PlayerId && !role.MediatedPlayers.Keys.Contains(x.ParentId)))
            {
                role.AddMediatePlayer(dead.PlayerId);
                Utils.Rpc(CustomRPC.Mediate, dead.PlayerId, PlayerControl.LocalPlayer.PlayerId);
                if (CustomGameOptions.DeadRevealed != DeadRevealed.All) return false;
            }

        return false;
    }
}