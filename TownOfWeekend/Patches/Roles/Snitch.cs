using System.Collections.Generic;
using System.Linq;
using TownOfWeekend.Extensions;
using TownOfWeekend.Patches;
using UnityEngine;

namespace TownOfWeekend.Roles;

public class Snitch : Role
{
    public List<ArrowBehaviour> ImpArrows = new();

    public Dictionary<byte, ArrowBehaviour> SnitchArrows = new();

    public Snitch(PlayerControl player) : base(player)
    {
        Name = "Snitch";
        ImpostorText = () => "Complete All Your Tasks To Discover The Impostors";
        TaskText = () =>
            TasksDone
                ? "Find the arrows pointing to the Impostors!"
                : "Complete all your tasks to discover the Impostors!";
        Color = Colors.Snitch;
        RoleType = RoleEnum.Snitch;
        AddToRoleHistory(RoleType);
    }

    public bool Revealed => TasksLeft <= CustomGameOptions.SnitchTasksRemaining;
    public bool TasksDone => TasksLeft <= 0;

    internal override bool Criteria()
    {
        return (Revealed && PlayerControl.LocalPlayer.Data.IsImpostor() && !Player.Data.IsDead) ||
               base.Criteria();
    }

    internal override bool RoleCriteria()
    {
        var localPlayer = PlayerControl.LocalPlayer;
        if (localPlayer.Data.IsImpostor() && !Player.Data.IsDead)
            return Revealed || base.RoleCriteria();
        if (GetRole(localPlayer).Faction == Faction.NeutralKilling && !Player.Data.IsDead)
            return (Revealed && CustomGameOptions.SnitchSeesNeutrals) || base.RoleCriteria();
        return false || base.RoleCriteria();
    }

    public void DestroyArrow(byte targetPlayerId)
    {
        var arrow = SnitchArrows.FirstOrDefault(x => x.Key == targetPlayerId);
        if (arrow.Value != null)
            Object.Destroy(arrow.Value);
        if (arrow.Value.gameObject != null)
            Object.Destroy(arrow.Value.gameObject);
        SnitchArrows.Remove(arrow.Key);
    }
}