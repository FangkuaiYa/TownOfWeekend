using System.Collections.Generic;
using TownOfWeekend.Patches;

namespace TownOfWeekend.Roles.Modifiers;

public class Radar : Modifier
{
    public PlayerControl ClosestPlayer;
    public List<ArrowBehaviour> RadarArrow = new();

    public Radar(PlayerControl player) : base(player)
    {
        Name = "Radar";
        TaskText = () => "Be on high alert";
        Color = Colors.Radar;
        ModifierType = ModifierEnum.Radar;
    }
}