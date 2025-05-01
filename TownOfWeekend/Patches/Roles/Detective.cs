using System;
using System.Collections.Generic;
using TownOfWeekend.Patches;

namespace TownOfWeekend.Roles;

public class Detective : Role
{
    private KillButton _examineButton;
    public PlayerControl ClosestPlayer;
    public DeadBody CurrentTarget;
    public List<byte> DetectedKillers = new();
    public PlayerControl LastKiller;

    public Detective(PlayerControl player) : base(player)
    {
        Name = "Detective";
        ImpostorText = () => "Find A Body Then Examine Players To Find Blood";
        TaskText = () => "Examine suspicious players to find evildoers";
        Color = Colors.Detective;
        LastExamined = DateTime.UtcNow;
        RoleType = RoleEnum.Detective;
        AddToRoleHistory(RoleType);
    }

    public DateTime LastExamined { get; set; }

    public KillButton ExamineButton
    {
        get => _examineButton;
        set
        {
            _examineButton = value;
            ExtraButtons.Clear();
            ExtraButtons.Add(value);
        }
    }

    public float ExamineTimer()
    {
        var utcNow = DateTime.UtcNow;
        var timeSpan = utcNow - LastExamined;
        var num = CustomGameOptions.ExamineCd * 1000f;
        var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
        if (flag2) return 0;
        return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
    }
}