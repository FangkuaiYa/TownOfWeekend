using TownOfWeekend.Patches;

namespace TownOfWeekend.Roles.Modifiers;

public class Torch : Modifier
{
    public Torch(PlayerControl player) : base(player)
    {
        Name = "Torch";
        TaskText = () => "You can see in the dark";
        Color = Colors.Torch;
        ModifierType = ModifierEnum.Torch;
    }
}