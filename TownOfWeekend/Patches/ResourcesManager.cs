using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using UnityEngine;

namespace TownOfWeekend.Patches;

internal class ResourcesManager
{
    internal static Sprite JanitorClean;
    internal static Sprite EngineerFix;
    internal static Sprite SwapperSwitch;
    internal static Sprite SwapperSwitchDisabled;
    internal static Sprite Footprint;
    internal static Sprite NormalKill;
    internal static Sprite MedicSprite;
    internal static Sprite SeerSprite;
    internal static Sprite SampleSprite;
    internal static Sprite MorphSprite;
    internal static Sprite Arrow;
    internal static Sprite MineSprite;
    internal static Sprite SwoopSprite;
    internal static Sprite DouseSprite;
    internal static Sprite IgniteSprite;
    internal static Sprite ReviveSprite;
    internal static Sprite ButtonSprite;
    internal static Sprite DisperseSprite;
    internal static Sprite CycleBackSprite;
    internal static Sprite CycleForwardSprite;
    internal static Sprite GuessSprite;
    internal static Sprite DragSprite;
    internal static Sprite DropSprite;
    internal static Sprite FlashSprite;
    internal static Sprite AlertSprite;
    internal static Sprite RememberSprite;
    internal static Sprite TrackSprite;
    internal static Sprite PlantSprite;
    internal static Sprite DetonateSprite;
    internal static Sprite TransportSprite;
    internal static Sprite MediateSprite;
    internal static Sprite VestSprite;
    internal static Sprite ProtectSprite;
    internal static Sprite BlackmailSprite;
    internal static Sprite BlackmailLetterSprite;
    internal static Sprite BlackmailOverlaySprite;
    internal static Sprite LighterSprite;
    internal static Sprite DarkerSprite;
    internal static Sprite InfectSprite;
    internal static Sprite RampageSprite;
    internal static Sprite TrapSprite;
    internal static Sprite InspectSprite;
    internal static Sprite ExamineSprite;
    internal static Sprite EscapeSprite;
    internal static Sprite MarkSprite;
    internal static Sprite Revive2Sprite;
    internal static Sprite WhisperSprite;
    internal static Sprite ImitateSelectSprite;
    internal static Sprite ImitateDeselectSprite;
    internal static Sprite ObserveSprite;
    internal static Sprite BiteSprite;
    internal static Sprite StakeSprite;
    internal static Sprite RevealSprite;
    internal static Sprite ConfessSprite;
    internal static Sprite NoAbilitySprite;
    internal static Sprite CamouflageSprite;
    internal static Sprite CamoSprintSprite;
    internal static Sprite CamoSprintFreezeSprite;
    internal static Sprite RadiateSprite;
    internal static Sprite SheriffKillSprite;
    internal static Sprite HackSprite;
    internal static Sprite MimicSprite;
    internal static Sprite LockSprite;

    internal static Sprite SettingsButtonSprite;
    internal static Sprite CrewSettingsButtonSprite;
    internal static Sprite NeutralSettingsButtonSprite;
    internal static Sprite ImposterSettingsButtonSprite;
    internal static Sprite ModifierSettingsButtonSprite;
    internal static Sprite ToWBanner;
    internal static Sprite UpdateTOWButton;
    internal static Sprite UpdateSubmergedButton;

    internal static Sprite ZoomPlusButton;
    internal static Sprite ZoomPlusActiveButton;
    internal static Sprite ZoomMinusButton;
    internal static Sprite ZoomMinusActiveButton;


    internal static Dictionary<string, Sprite> CachedSprites = new();
    internal static d_LoadImage iCall_LoadImage;

    internal static Sprite loadSpriteFromResources(string path, float pixelsPerUnit = 100f)
    {
        try
        {
            if (CachedSprites.TryGetValue(path + pixelsPerUnit, out var sprite)) return sprite;
            var texture = loadTextureFromResources(path);
            sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f),
                pixelsPerUnit);
            sprite.hideFlags |= HideFlags.HideAndDontSave | HideFlags.DontSaveInEditor;
            return CachedSprites[path + pixelsPerUnit] = sprite;
        }
        catch
        {
            System.Console.WriteLine("Error loading sprite from path: " + path);
        }

        return null;
    }

    internal static unsafe Texture2D loadTextureFromResources(string path)
    {
        try
        {
            Texture2D texture = new(2, 2, TextureFormat.ARGB32, true);
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(path);
            var length = stream.Length;
            var byteTexture = new Il2CppStructArray<byte>(length);
            stream.Read(new Span<byte>(IntPtr.Add(byteTexture.Pointer, IntPtr.Size * 4).ToPointer(), (int)length));
            if (path.Contains("HorseHats")) byteTexture = new Il2CppStructArray<byte>(byteTexture.Reverse().ToArray());
            texture.LoadImage(byteTexture, false);
            return texture;
        }
        catch
        {
            System.Console.WriteLine("Error loading texture from resources: " + path);
        }

        return null;
    }

    internal static bool LoadImage(Texture2D tex, byte[] data, bool markNonReadable)
    {
        if (iCall_LoadImage == null)
            iCall_LoadImage = IL2CPP.ResolveICall<d_LoadImage>("UnityEngine.ImageConversion::LoadImage");
        var il2cppArray = (Il2CppStructArray<byte>)data;
        return iCall_LoadImage.Invoke(tex.Pointer, il2cppArray.Pointer, markNonReadable);
    }

    internal static void loadResources()
    {
        JanitorClean = loadSpriteFromResources("TownOfWeekend.Resources.Janitor.png");
        EngineerFix = loadSpriteFromResources("TownOfWeekend.Resources.Engineer.png");
        SwapperSwitch = loadSpriteFromResources("TownOfWeekend.Resources.SwapperSwitch.png");
        SwapperSwitchDisabled = loadSpriteFromResources("TownOfWeekend.Resources.SwapperSwitchDisabled.png");
        Footprint = loadSpriteFromResources("TownOfWeekend.Resources.Footprint.png");
        NormalKill = loadSpriteFromResources("TownOfWeekend.Resources.NormalKill.png");
        MedicSprite = loadSpriteFromResources("TownOfWeekend.Resources.Medic.png");
        SeerSprite = loadSpriteFromResources("TownOfWeekend.Resources.Seer.png");
        SampleSprite = loadSpriteFromResources("TownOfWeekend.Resources.Sample.png");
        MorphSprite = loadSpriteFromResources("TownOfWeekend.Resources.Morph.png");
        Arrow = loadSpriteFromResources("TownOfWeekend.Resources.Arrow.png");
        MineSprite = loadSpriteFromResources("TownOfWeekend.Resources.Mine.png");
        SwoopSprite = loadSpriteFromResources("TownOfWeekend.Resources.Swoop.png");
        DouseSprite = loadSpriteFromResources("TownOfWeekend.Resources.Douse.png");
        IgniteSprite = loadSpriteFromResources("TownOfWeekend.Resources.Ignite.png");
        ReviveSprite = loadSpriteFromResources("TownOfWeekend.Resources.Revive.png");
        ButtonSprite = loadSpriteFromResources("TownOfWeekend.Resources.Button.png");
        DisperseSprite = loadSpriteFromResources("TownOfWeekend.Resources.Disperse.png");
        DragSprite = loadSpriteFromResources("TownOfWeekend.Resources.Drag.png");
        DropSprite = loadSpriteFromResources("TownOfWeekend.Resources.Drop.png");
        CycleBackSprite = loadSpriteFromResources("TownOfWeekend.Resources.CycleBack.png");
        CycleForwardSprite = loadSpriteFromResources("TownOfWeekend.Resources.CycleForward.png");
        GuessSprite = loadSpriteFromResources("TownOfWeekend.Resources.Guess.png");
        FlashSprite = loadSpriteFromResources("TownOfWeekend.Resources.Flash.png");
        AlertSprite = loadSpriteFromResources("TownOfWeekend.Resources.Alert.png");
        RememberSprite = loadSpriteFromResources("TownOfWeekend.Resources.Remember.png");
        TrackSprite = loadSpriteFromResources("TownOfWeekend.Resources.Track.png");
        PlantSprite = loadSpriteFromResources("TownOfWeekend.Resources.Plant.png");
        DetonateSprite = loadSpriteFromResources("TownOfWeekend.Resources.Detonate.png");
        TransportSprite = loadSpriteFromResources("TownOfWeekend.Resources.Transport.png");
        MediateSprite = loadSpriteFromResources("TownOfWeekend.Resources.Mediate.png");
        VestSprite = loadSpriteFromResources("TownOfWeekend.Resources.Vest.png");
        ProtectSprite = loadSpriteFromResources("TownOfWeekend.Resources.Protect.png");
        BlackmailSprite = loadSpriteFromResources("TownOfWeekend.Resources.Blackmail.png");
        BlackmailLetterSprite = loadSpriteFromResources("TownOfWeekend.Resources.BlackmailLetter.png");
        BlackmailOverlaySprite = loadSpriteFromResources("TownOfWeekend.Resources.BlackmailOverlay.png");
        LighterSprite = loadSpriteFromResources("TownOfWeekend.Resources.Lighter.png");
        DarkerSprite = loadSpriteFromResources("TownOfWeekend.Resources.Darker.png");
        InfectSprite = loadSpriteFromResources("TownOfWeekend.Resources.Infect.png");
        RampageSprite = loadSpriteFromResources("TownOfWeekend.Resources.Rampage.png");
        TrapSprite = loadSpriteFromResources("TownOfWeekend.Resources.Trap.png");
        InspectSprite = loadSpriteFromResources("TownOfWeekend.Resources.Inspect.png");
        ExamineSprite = loadSpriteFromResources("TownOfWeekend.Resources.Examine.png");
        EscapeSprite = loadSpriteFromResources("TownOfWeekend.Resources.Recall.png");
        MarkSprite = loadSpriteFromResources("TownOfWeekend.Resources.Mark.png");
        Revive2Sprite = loadSpriteFromResources("TownOfWeekend.Resources.Revive2.png");
        WhisperSprite = loadSpriteFromResources("TownOfWeekend.Resources.Whisper.png");
        ImitateSelectSprite = loadSpriteFromResources("TownOfWeekend.Resources.ImitateSelect.png");
        ImitateDeselectSprite = loadSpriteFromResources("TownOfWeekend.Resources.ImitateDeselect.png");
        ObserveSprite = loadSpriteFromResources("TownOfWeekend.Resources.Observe.png");
        BiteSprite = loadSpriteFromResources("TownOfWeekend.Resources.Bite.png");
        StakeSprite = loadSpriteFromResources("TownOfWeekend.Resources.Stake.png");
        RevealSprite = loadSpriteFromResources("TownOfWeekend.Resources.Reveal.png");
        ConfessSprite = loadSpriteFromResources("TownOfWeekend.Resources.Confess.png");
        NoAbilitySprite = loadSpriteFromResources("TownOfWeekend.Resources.NoAbility.png");
        CamouflageSprite = loadSpriteFromResources("TownOfWeekend.Resources.Camouflage.png");
        CamoSprintSprite = loadSpriteFromResources("TownOfWeekend.Resources.CamoSprint.png");
        CamoSprintFreezeSprite = loadSpriteFromResources("TownOfWeekend.Resources.CamoSprintFreeze.png");
        RadiateSprite = loadSpriteFromResources("TownOfWeekend.Resources.Radiate.png");
        SheriffKillSprite = loadSpriteFromResources("TownOfWeekend.Resources.SheriffKill.png");
        HackSprite = loadSpriteFromResources("TownOfWeekend.Resources.Hack.png");
        MimicSprite = loadSpriteFromResources("TownOfWeekend.Resources.Mimic.png");
        LockSprite = loadSpriteFromResources("TownOfWeekend.Resources.Lock.png");

        SettingsButtonSprite = loadSpriteFromResources("TownOfWeekend.Resources.SettingsButton.png");
        CrewSettingsButtonSprite = loadSpriteFromResources("TownOfWeekend.Resources.Crewmate.png");
        NeutralSettingsButtonSprite = loadSpriteFromResources("TownOfWeekend.Resources.Neutral.png");
        ImposterSettingsButtonSprite = loadSpriteFromResources("TownOfWeekend.Resources.Impostor.png");
        ModifierSettingsButtonSprite = loadSpriteFromResources("TownOfWeekend.Resources.Modifiers.png");
        ToWBanner = loadSpriteFromResources("TownOfWeekend.Resources.TownOfWeekendBanner.png", 300f);
        UpdateTOWButton = loadSpriteFromResources("TownOfWeekend.Resources.UpdateToWButton.png");
        UpdateSubmergedButton = loadSpriteFromResources("TownOfWeekend.Resources.UpdateSubmergedButton.png");

        ZoomPlusButton = loadSpriteFromResources("TownOfWeekend.Resources.Plus.png");
        ZoomPlusActiveButton = loadSpriteFromResources("TownOfWeekend.Resources.PlusActive.png");
        ZoomMinusButton = loadSpriteFromResources("TownOfWeekend.Resources.Minus.png");
        ZoomMinusActiveButton = loadSpriteFromResources("TownOfWeekend.Resources.MinusActive.png");
    }

    internal delegate bool d_LoadImage(IntPtr tex, IntPtr data, bool markNonReadable);
}