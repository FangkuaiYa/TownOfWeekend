using TownOfWeekend.Patches;

namespace TownOfWeekend.Roles.Modifiers;

public class Tiebreaker : Modifier
{
    public Tiebreaker(PlayerControl player) : base(player)
    {
        Name = "Tiebreaker";
        TaskText = () => "Your vote breaks ties";
        Color = Colors.Tiebreaker;
        ModifierType = ModifierEnum.Tiebreaker;
    }
}