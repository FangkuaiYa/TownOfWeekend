using TownOfWeekend.Patches;
using UnityEngine;

namespace TownOfWeekend.Roles;

public class Mayor : Role
{
    public GameObject RevealButton = new();

    public Mayor(PlayerControl player) : base(player)
    {
        Name = "Mayor";
        ImpostorText = () => "Reveal Yourself To Save The Town";
        TaskText = () => "Reveal yourself when the time is right";
        Color = Colors.Mayor;
        RoleType = RoleEnum.Mayor;
        AddToRoleHistory(RoleType);
        Revealed = false;
    }

    public bool Revealed { get; set; }

    internal override bool Criteria()
    {
        return (Revealed && !Player.Data.IsDead) || base.Criteria();
    }

    internal override bool RoleCriteria()
    {
        if (!Player.Data.IsDead) return Revealed || base.RoleCriteria();
        return false || base.RoleCriteria();
    }
}