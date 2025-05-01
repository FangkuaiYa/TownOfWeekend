using TownOfWeekend.Patches;

namespace TownOfWeekend.Roles.Modifiers;

public class Multitasker : Modifier
{
    public Multitasker(PlayerControl player) : base(player)
    {
        Name = "Multitasker";
        TaskText = () => "Your task windows are transparent";
        Color = Colors.Multitasker;
        ModifierType = ModifierEnum.Multitasker;
    }
}