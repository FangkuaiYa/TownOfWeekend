using System;
using System.Collections.Generic;
using System.Linq;
using Hazel;
using Reactor.Networking.Extensions;
using Reactor.Utilities;
using Reactor.Utilities.Extensions;
using TownOfWeekend.Patches;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TownOfWeekend.Roles.Modifiers;

public class Disperser : Modifier
{
    public bool ButtonUsed;
    public KillButton DisperseButton;

    public Disperser(PlayerControl player) : base(player)
    {
        Name = "Disperser";
        TaskText = () => "Separate the Crew";
        Color = Colors.Impostor;
        StartingCooldown = DateTime.UtcNow;
        ModifierType = ModifierEnum.Disperser;

        Logger<TownOfWeekendPlugin>.Info("DISPERSER -==-=-=-=-=-=-=-=-=----------");
        if (PlayerControl.LocalPlayer == player) Logger<TownOfWeekendPlugin>.Info("ME -==-=-=-=-=-=-=-=-=----------");
    }

    public DateTime StartingCooldown { get; set; }

    public float StartTimer()
    {
        var utcNow = DateTime.UtcNow;
        var timeSpan = utcNow - StartingCooldown;
        var num = 10000f;
        var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
        if (flag2) return 0;
        return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
    }

    public void Disperse()
    {
        var coordinates = GenerateDisperseCoordinates();

        var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
            (byte)CustomRPC.Disperse,
            SendOption.Reliable);
        writer.Write((byte)coordinates.Count);
        foreach (var (key, value) in coordinates)
        {
            writer.Write(key);
            writer.Write(value);
        }

        AmongUsClient.Instance.FinishRpcImmediately(writer);

        DispersePlayersToCoordinates(coordinates);
    }

    public static void DispersePlayersToCoordinates(Dictionary<byte, Vector2> coordinates)
    {
        if (coordinates.ContainsKey(PlayerControl.LocalPlayer.PlayerId))
        {
            Coroutines.Start(Utils.FlashCoroutine(Palette.ImpostorRed));
            if (Minigame.Instance)
                try
                {
                    Minigame.Instance.Close();
                }
                catch
                {
                }

            if (PlayerControl.LocalPlayer.inVent)
            {
                PlayerControl.LocalPlayer.MyPhysics.RpcExitVent(Vent.currentVent.Id);
                PlayerControl.LocalPlayer.MyPhysics.ExitAllVents();
            }
        }


        foreach (var (key, value) in coordinates)
        {
            var player = Utils.PlayerById(key);
            player.transform.position = value;
            if (PlayerControl.LocalPlayer == player) PlayerControl.LocalPlayer.NetTransform.RpcSnapTo(value);
        }

        if (PlayerControl.LocalPlayer.walkingToVent)
        {
            PlayerControl.LocalPlayer.inVent = false;
            Vent.currentVent = null;
            PlayerControl.LocalPlayer.moveable = true;
            PlayerControl.LocalPlayer.MyPhysics.StopAllCoroutines();
        }

        if (SubmergedCompatibility.isSubmerged())
            SubmergedCompatibility.ChangeFloor(PlayerControl.LocalPlayer.transform.position.y > -7f);
    }

    private Dictionary<byte, Vector2> GenerateDisperseCoordinates()
    {
        var targets = PlayerControl.AllPlayerControls.ToArray()
            .Where(player => !player.Data.IsDead && !player.Data.Disconnected).ToList();

        var vents = Object.FindObjectsOfType<Vent>().ToHashSet();

        var coordinates = new Dictionary<byte, Vector2>(targets.Count);
        foreach (var target in targets)
        {
            var vent = vents.Random();

            var destination = SendPlayerToVent(vent);
            coordinates.Add(target.PlayerId, destination);
        }

        return coordinates;
    }

    public static Vector3 SendPlayerToVent(Vent vent)
    {
        var size = vent.GetComponent<BoxCollider2D>().size;
        var destination = vent.transform.position;
        destination.y += 0.3636f;
        return destination;
    }
}