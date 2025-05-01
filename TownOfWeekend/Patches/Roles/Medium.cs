using System;
using System.Collections.Generic;
using Reactor.Utilities;
using TownOfWeekend.Patches;
using UnityEngine;

namespace TownOfWeekend.Roles;

public class Medium : Role
{
    public Dictionary<byte, ArrowBehaviour> MediatedPlayers = new();

    public Medium(PlayerControl player) : base(player)
    {
        Name = "Medium";
        ImpostorText = () => "Watch The Spooky Ghosts";
        TaskText = () => "Follow ghosts to get clues from them";
        Color = Colors.Medium;
        LastMediated = DateTime.UtcNow;
        RoleType = RoleEnum.Medium;
        AddToRoleHistory(RoleType);
        Scale = 1.4f;
        MediatedPlayers = new Dictionary<byte, ArrowBehaviour>();
    }

    public DateTime LastMediated { get; set; }

    public static Sprite Arrow => ResourcesManager.Arrow;

    internal override bool RoleCriteria()
    {
        return (MediatedPlayers.ContainsKey(PlayerControl.LocalPlayer.PlayerId) &&
                CustomGameOptions.ShowMediumToDead) || base.RoleCriteria();
    }

    public float MediateTimer()
    {
        var utcNow = DateTime.UtcNow;
        var timeSpan = utcNow - LastMediated;
        var num = CustomGameOptions.MediateCooldown * 1000f;
        var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
        if (flag2) return 0;
        return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
    }

    public void AddMediatePlayer(byte playerId)
    {
        var gameObj = new GameObject();
        var arrow = gameObj.AddComponent<ArrowBehaviour>();
        if (Player.PlayerId == PlayerControl.LocalPlayer.PlayerId || CustomGameOptions.ShowMediumToDead)
        {
            gameObj.transform.parent = PlayerControl.LocalPlayer.gameObject.transform;
            var renderer = gameObj.AddComponent<SpriteRenderer>();
            renderer.sprite = Arrow;
            arrow.image = renderer;
            gameObj.layer = 5;
            arrow.target = Utils.PlayerById(playerId).transform.position;
        }

        MediatedPlayers.Add(playerId, arrow);
        Coroutines.Start(Utils.FlashCoroutine(Color));
    }
}