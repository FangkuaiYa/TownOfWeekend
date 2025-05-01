namespace TownOfWeekend.Roles;

public interface IVisualAlteration
{
    bool TryGetModifiedAppearance(out VisualAppearance appearance);
}