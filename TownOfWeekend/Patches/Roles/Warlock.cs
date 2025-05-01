using System;
using TMPro;
using TownOfWeekend.Patches;

namespace TownOfWeekend.Roles;

public class Warlock : Role
{
    public int ChargePercent;

    public TextMeshPro ChargeText;
    public float ChargeUseDuration;
    public bool Charging;
    public DateTime StartChargeTime;
    public DateTime StartUseTime;
    public bool UsingCharge;

    public Warlock(PlayerControl player) : base(player)
    {
        Name = "Warlock";
        ImpostorText = () => "Charge Up Your Kill Button To Multi Kill";
        TaskText = () => "Kill people in small bursts";
        Color = Colors.Impostor;
        RoleType = RoleEnum.Warlock;
        AddToRoleHistory(RoleType);
        Faction = Faction.Impostors;
        ChargePercent = 0;
    }

    public int ChargeUpTimer()
    {
        var utcNow = DateTime.UtcNow;
        var timeSpan = utcNow - StartChargeTime;
        var num = CustomGameOptions.ChargeUpDuration * 1000f;
        var result = (float)timeSpan.TotalMilliseconds / num * 100f;
        if (result > 100f) result = 100f;
        return Convert.ToInt32(Math.Round(result));
    }

    public int ChargeUseTimer()
    {
        var utcNow = DateTime.UtcNow;
        var timeSpan = StartUseTime - utcNow;
        var num = ChargeUseDuration * 1000f;
        var result = ((float)timeSpan.TotalMilliseconds / num + 1) * ChargeUseDuration /
            CustomGameOptions.ChargeUseDuration * 100f;
        if (result < 0f) result = 0f;
        return Convert.ToInt32(Math.Round(result));
    }
}