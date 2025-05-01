using System;
using Il2CppSystem.Collections.Generic;
using TownOfWeekend.CrewmateRoles.MedicMod;
using TownOfWeekend.ImpostorRoles.BomberMod;
using TownOfWeekend.Patches;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TownOfWeekend.Roles;

public class Bomber : Role

{
    public static Material bombMaterial = TownOfWeekendPlugin.bundledAssets.Get<Material>("bomb");
    public KillButton _plantButton;
    public Bomb Bomb = new();
    public bool Detonated = true;
    public Vector3 DetonatePoint;
    public bool Enabled;
    public float TimeRemaining;

    public Bomber(PlayerControl player) : base(player)
    {
        Name = "Bomber";
        ImpostorText = () => "Plant Bombs To Kill Multiple Crewmates At Once";
        TaskText = () => "Plant bombs to kill crewmates";
        Color = Palette.ImpostorRed;
        StartingCooldown = DateTime.UtcNow;
        RoleType = RoleEnum.Bomber;
        AddToRoleHistory(RoleType);
        Faction = Faction.Impostors;
    }

    public DateTime StartingCooldown { get; set; }

    public KillButton PlantButton
    {
        get => _plantButton;
        set
        {
            _plantButton = value;
            ExtraButtons.Clear();
            ExtraButtons.Add(value);
        }
    }

    public bool Detonating => TimeRemaining > 0f;

    public float StartTimer()
    {
        var utcNow = DateTime.UtcNow;
        var timeSpan = utcNow - StartingCooldown;
        var num = 10000f;
        var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
        if (flag2) return 0;
        return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
    }

    public void DetonateTimer()
    {
        Enabled = true;
        TimeRemaining -= Time.deltaTime;
        if (MeetingHud.Instance) Detonated = true;
        if (TimeRemaining <= 0 && !Detonated)
        {
            var bomber = GetRole<Bomber>(PlayerControl.LocalPlayer);
            bomber.Bomb.ClearBomb();
            DetonateKillStart();
        }
    }

    public void DetonateKillStart()
    {
        Detonated = true;
        var playersToDie = Utils.GetClosestPlayers(DetonatePoint, CustomGameOptions.DetonateRadius, false);
        playersToDie = Shuffle(playersToDie);
        while (playersToDie.Count > CustomGameOptions.MaxKillsInDetonation)
            playersToDie.Remove(playersToDie[playersToDie.Count - 1]);
        foreach (var player in playersToDie)
            if (!player.Is(RoleEnum.Pestilence) && !player.IsShielded() && !player.IsProtected() &&
                player != ShowRoundOneShield.FirstRoundShielded)
            {
                Utils.RpcMultiMurderPlayer(Player, player);
            }
            else if (player.IsShielded())
            {
                var medic = player.GetMedic().Player.PlayerId;
                Utils.Rpc(CustomRPC.AttemptSound, medic, player.PlayerId);
                StopKill.BreakShield(medic, player.PlayerId, CustomGameOptions.ShieldBreaks);
            }
    }

    public static List<PlayerControl> Shuffle(
        List<PlayerControl> playersToDie)
    {
        var count = playersToDie.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = playersToDie[i];
            playersToDie[i] = playersToDie[r];
            playersToDie[r] = tmp;
        }

        return playersToDie;
    }
}