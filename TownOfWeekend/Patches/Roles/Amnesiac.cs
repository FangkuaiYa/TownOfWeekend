using System.Collections.Generic;
using System.Linq;
using TownOfWeekend.Patches;
using Object = UnityEngine.Object;

namespace TownOfWeekend.Roles;

public class Amnesiac : Role
{
    public Dictionary<byte, ArrowBehaviour> BodyArrows = new();

    public DeadBody CurrentTarget;
    public bool SpawnedAs = true;

    public Amnesiac(PlayerControl player) : base(player)
    {
        Name = "Amnesiac";
        ImpostorText = () => "Remember A Role Of A Deceased Player";
        TaskText = () =>
            SpawnedAs ? "Find a dead body to remember a role" : "Your target was killed. Now remember a new role!";
        Color = Colors.Amnesiac;
        RoleType = RoleEnum.Amnesiac;
        AddToRoleHistory(RoleType);
        Faction = Faction.NeutralBenign;
    }

    protected override void IntroPrefix(IntroCutscene._ShowTeam_d__38 __instance)
    {
        var amnesiacTeam = new Il2CppSystem.Collections.Generic.List<PlayerControl>();
        amnesiacTeam.Add(PlayerControl.LocalPlayer);
        __instance.teamToShow = amnesiacTeam;
    }

    public void DestroyArrow(byte targetPlayerId)
    {
        var arrow = BodyArrows.FirstOrDefault(x => x.Key == targetPlayerId);
        if (arrow.Value != null)
            Object.Destroy(arrow.Value);
        if (arrow.Value.gameObject != null)
            Object.Destroy(arrow.Value.gameObject);
        BodyArrows.Remove(arrow.Key);
    }
}