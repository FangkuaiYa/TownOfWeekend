using System.Collections.Generic;
using TownOfWeekend.Patches;

namespace TownOfWeekend.Roles.Modifiers;

public class Sleuth : Modifier
{
    public List<byte> Reported = new();

    public Sleuth(PlayerControl player) : base(player)
    {
        Name = "Sleuth";
        TaskText = () => "Know the roles of bodies you report";
        Color = Colors.Sleuth;
        ModifierType = ModifierEnum.Sleuth;
    }
}