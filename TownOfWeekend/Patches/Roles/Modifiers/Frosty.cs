using System;
using TownOfWeekend.Patches;

namespace TownOfWeekend.Roles.Modifiers;

public class Frosty : Modifier
{
    public PlayerControl Chilled;
    public bool IsChilled = false;

    public Frosty(PlayerControl player) : base(player)
    {
        Name = "Frosty";
        TaskText = () => "Leave behind an icy surprise";
        Color = Colors.Frosty;
        ModifierType = ModifierEnum.Frosty;
    }

    public DateTime LastChilled { get; set; }
}