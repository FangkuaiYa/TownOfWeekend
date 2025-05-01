using System;
using TMPro;
using TownOfWeekend.Patches;

namespace TownOfWeekend.Roles;

public class VampireHunter : Role
{
    public bool AddedStakes;
    public PlayerControl ClosestPlayer;

    public int UsesLeft;
    public TextMeshPro UsesText;

    public VampireHunter(PlayerControl player) : base(player)
    {
        Name = "Vampire Hunter";
        ImpostorText = () => "Stake The Vampires";
        TaskText = () => "Stake the Vampires";
        Color = Colors.VampireHunter;
        LastStaked = DateTime.UtcNow;
        RoleType = RoleEnum.VampireHunter;
        AddToRoleHistory(RoleType);

        UsesLeft = 0;
        AddedStakes = false;
    }

    public DateTime LastStaked { get; set; }

    public bool ButtonUsable => UsesLeft != 0;

    public float StakeTimer()
    {
        var utcNow = DateTime.UtcNow;
        var timeSpan = utcNow - LastStaked;
        var num = CustomGameOptions.StakeCd * 1000f;
        var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
        if (flag2) return 0;
        return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
    }
}