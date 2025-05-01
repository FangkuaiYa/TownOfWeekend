using System;
using TownOfWeekend.Patches;
using UnityEngine;

namespace TownOfWeekend.CustomOption;

public class Generate
{
    public static CustomHeaderOption CrewInvestigativeRoles;

    public static CustomNumberOption AurialOn;
    public static CustomNumberOption RadiateRange;
    public static CustomNumberOption RadiateCooldown;
    public static CustomNumberOption RadiateSucceedChance;
    public static CustomNumberOption RadiateCount;
    public static CustomNumberOption RadiateInvis;

    public static CustomNumberOption DetectiveOn;
    public static CustomNumberOption ExamineCooldown;
    public static CustomToggleOption DetectiveReportOn;
    public static CustomNumberOption DetectiveRoleDuration;
    public static CustomNumberOption DetectiveFactionDuration;
    public static CustomToggleOption CanDetectLastKiller;

    public static CustomNumberOption HaunterOn;
    public static CustomNumberOption HaunterTasksRemainingClicked;
    public static CustomNumberOption HaunterTasksRemainingAlert;
    public static CustomToggleOption HaunterRevealsNeutrals;
    public static CustomStringOption HaunterCanBeClickedBy;

    public static CustomNumberOption InvestigatorOn;
    public static CustomNumberOption FootprintSize;
    public static CustomNumberOption FootprintInterval;
    public static CustomNumberOption FootprintDuration;
    public static CustomToggleOption AnonymousFootPrint;
    public static CustomToggleOption VentFootprintVisible;

    public static CustomNumberOption MysticOn;
    public static CustomNumberOption MysticArrowDuration;

    public static CustomNumberOption OracleOn;
    public static CustomNumberOption ConfessCooldown;
    public static CustomNumberOption RevealAccuracy;
    public static CustomToggleOption NeutralBenignShowsEvil;
    public static CustomToggleOption NeutralEvilShowsEvil;
    public static CustomToggleOption NeutralKillingShowsEvil;

    public static CustomNumberOption SeerOn;
    public static CustomNumberOption SeerCooldown;
    public static CustomToggleOption CrewKillingRed;
    public static CustomToggleOption NeutBenignRed;
    public static CustomToggleOption NeutEvilRed;
    public static CustomToggleOption NeutKillingRed;
    public static CustomToggleOption TraitorColourSwap;

    public static CustomNumberOption SnitchOn;
    public static CustomToggleOption SnitchSeesNeutrals;
    public static CustomNumberOption SnitchTasksRemaining;
    public static CustomToggleOption SnitchSeesImpInMeeting;
    public static CustomToggleOption SnitchSeesTraitor;

    public static CustomNumberOption SpyOn;
    public static CustomStringOption WhoSeesDead;

    public static CustomNumberOption TrackerOn;
    public static CustomNumberOption UpdateInterval;
    public static CustomNumberOption TrackCooldown;
    public static CustomToggleOption ResetOnNewRound;
    public static CustomNumberOption MaxTracks;

    public static CustomNumberOption TrapperOn;
    public static CustomNumberOption TrapCooldown;
    public static CustomToggleOption TrapsRemoveOnNewRound;
    public static CustomNumberOption MaxTraps;
    public static CustomNumberOption MinAmountOfTimeInTrap;
    public static CustomNumberOption TrapSize;
    public static CustomNumberOption MinAmountOfPlayersInTrap;


    public static CustomHeaderOption CrewProtectiveRoles;

    public static CustomNumberOption AltruistOn;
    public static CustomNumberOption ReviveDuration;
    public static CustomToggleOption AltruistTargetBody;

    public static CustomNumberOption MedicOn;
    public static CustomStringOption ShowShielded;
    public static CustomStringOption WhoGetsNotification;
    public static CustomToggleOption ShieldBreaks;
    public static CustomToggleOption MedicReportSwitch;
    public static CustomNumberOption MedicReportNameDuration;
    public static CustomNumberOption MedicReportColorDuration;


    public static CustomHeaderOption CrewKillingRoles;

    public static CustomNumberOption SheriffOn;
    public static CustomToggleOption SheriffKillOther;
    public static CustomToggleOption SheriffKillsDoomsayer;
    public static CustomToggleOption SheriffKillsExecutioner;
    public static CustomToggleOption SheriffKillsJester;
    public static CustomToggleOption SheriffKillsArsonist;
    public static CustomToggleOption SheriffKillsJuggernaut;
    public static CustomToggleOption SheriffKillsPlaguebearer;
    public static CustomToggleOption SheriffKillsGlitch;
    public static CustomToggleOption SheriffKillsVampire;
    public static CustomToggleOption SheriffKillsWerewolf;
    public static CustomNumberOption SheriffKillCd;
    public static CustomToggleOption SheriffBodyReport;

    public static CustomNumberOption VampireHunterOn;
    public static CustomNumberOption StakeCooldown;
    public static CustomNumberOption MaxFailedStakesPerGame;
    public static CustomToggleOption CanStakeRoundOne;
    public static CustomToggleOption SelfKillAfterFinalStake;
    public static CustomStringOption BecomeOnVampDeaths;

    public static CustomNumberOption VeteranOn;
    public static CustomToggleOption KilledOnAlert;
    public static CustomNumberOption AlertCooldown;
    public static CustomNumberOption AlertDuration;
    public static CustomNumberOption MaxAlerts;

    public static CustomNumberOption VigilanteOn;
    public static CustomNumberOption VigilanteKills;
    public static CustomToggleOption VigilanteMultiKill;
    public static CustomToggleOption VigilanteGuessNeutralBenign;
    public static CustomToggleOption VigilanteGuessNeutralEvil;
    public static CustomToggleOption VigilanteGuessNeutralKilling;
    public static CustomToggleOption VigilanteGuessLovers;
    public static CustomToggleOption VigilanteAfterVoting;


    public static CustomHeaderOption CrewSupportRoles;

    public static CustomNumberOption EngineerOn;
    public static CustomNumberOption MaxFixes;

    public static CustomNumberOption ImitatorOn;

    public static CustomNumberOption MayorOn;

    public static CustomNumberOption MediumOn;
    public static CustomNumberOption MediateCooldown;
    public static CustomToggleOption ShowMediatePlayer;
    public static CustomToggleOption ShowMediumToDead;
    public static CustomStringOption DeadRevealed;

    public static CustomNumberOption ProsecutorOn;
    public static CustomToggleOption ProsDiesOnIncorrectPros;

    public static CustomNumberOption SwapperOn;
    public static CustomToggleOption SwapperButton;

    public static CustomNumberOption TransporterOn;
    public static CustomNumberOption TransportCooldown;
    public static CustomNumberOption TransportMaxUses;
    public static CustomToggleOption TransporterVitals;


    public static CustomHeaderOption NeutralBenignRoles;

    public static CustomNumberOption AmnesiacOn;
    public static CustomToggleOption RememberArrows;
    public static CustomNumberOption RememberArrowDelay;

    public static CustomNumberOption GuardianAngelOn;
    public static CustomNumberOption ProtectCd;
    public static CustomNumberOption ProtectDuration;
    public static CustomNumberOption ProtectKCReset;
    public static CustomNumberOption MaxProtects;
    public static CustomStringOption ShowProtect;
    public static CustomStringOption GaOnTargetDeath;
    public static CustomToggleOption GATargetKnows;
    public static CustomToggleOption GAKnowsTargetRole;
    public static CustomNumberOption EvilTargetPercent;

    public static CustomNumberOption SurvivorOn;
    public static CustomNumberOption VestCd;
    public static CustomNumberOption VestDuration;
    public static CustomNumberOption VestKCReset;
    public static CustomNumberOption MaxVests;


    public static CustomHeaderOption NeutralEvilRoles;

    public static CustomNumberOption DoomsayerOn;
    public static CustomNumberOption ObserveCooldown;
    public static CustomToggleOption DoomsayerGuessNeutralBenign;
    public static CustomToggleOption DoomsayerGuessNeutralEvil;
    public static CustomToggleOption DoomsayerGuessNeutralKilling;
    public static CustomToggleOption DoomsayerGuessImpostors;
    public static CustomToggleOption DoomsayerAfterVoting;
    public static CustomNumberOption DoomsayerGuessesToWin;

    public static CustomNumberOption ExecutionerOn;
    public static CustomStringOption OnTargetDead;
    public static CustomToggleOption ExecutionerButton;
    public static CustomToggleOption ExecutionerTorment;

    public static CustomNumberOption JesterOn;
    public static CustomToggleOption JesterButton;
    public static CustomToggleOption JesterVent;
    public static CustomToggleOption JesterImpVision;
    public static CustomToggleOption JesterHaunt;

    public static CustomNumberOption PhantomOn;
    public static CustomNumberOption PhantomTasksRemaining;
    public static CustomToggleOption PhantomSpook;


    public static CustomHeaderOption NeutralKillingRoles;

    public static CustomNumberOption ArsonistOn;
    public static CustomNumberOption DouseCooldown;
    public static CustomNumberOption MaxDoused;
    public static CustomToggleOption ArsoImpVision;
    public static CustomToggleOption IgniteCdRemoved;

    public static CustomNumberOption PlaguebearerOn;
    public static CustomNumberOption InfectCooldown;
    public static CustomNumberOption PestKillCooldown;
    public static CustomToggleOption PestVent;

    public static CustomNumberOption GlitchOn;
    public static CustomNumberOption MimicCooldownOption;
    public static CustomNumberOption MimicDurationOption;
    public static CustomNumberOption HackCooldownOption;
    public static CustomNumberOption HackDurationOption;
    public static CustomNumberOption GlitchKillCooldownOption;
    public static CustomStringOption GlitchHackDistanceOption;
    public static CustomToggleOption GlitchVent;

    public static CustomNumberOption VampireOn;
    public static CustomNumberOption BiteCooldown;
    public static CustomToggleOption VampImpVision;
    public static CustomToggleOption VampVent;
    public static CustomToggleOption NewVampCanAssassin;
    public static CustomNumberOption MaxVampiresPerGame;
    public static CustomToggleOption CanBiteNeutralBenign;
    public static CustomToggleOption CanBiteNeutralEvil;

    public static CustomNumberOption WerewolfOn;
    public static CustomNumberOption RampageCooldown;
    public static CustomNumberOption RampageDuration;
    public static CustomNumberOption RampageKillCooldown;
    public static CustomToggleOption WerewolfVent;

    public static CustomHeaderOption Juggernaut;
    public static CustomNumberOption JuggKillCooldown;
    public static CustomNumberOption ReducedKCdPerKill;
    public static CustomToggleOption JuggVent;


    public static CustomHeaderOption ImpostorConcealingRoles;

    public static CustomNumberOption EscapistOn;
    public static CustomNumberOption EscapeCooldown;
    public static CustomToggleOption EscapistVent;

    public static CustomNumberOption MorphlingOn;
    public static CustomNumberOption MorphlingCooldown;
    public static CustomNumberOption MorphlingDuration;
    public static CustomToggleOption MorphlingVent;

    public static CustomNumberOption SwooperOn;
    public static CustomNumberOption SwoopCooldown;
    public static CustomNumberOption SwoopDuration;
    public static CustomToggleOption SwooperVent;

    public static CustomNumberOption GrenadierOn;
    public static CustomNumberOption GrenadeCooldown;
    public static CustomNumberOption GrenadeDuration;
    public static CustomToggleOption GrenadierIndicators;
    public static CustomToggleOption GrenadierVent;
    public static CustomNumberOption FlashRadius;

    public static CustomNumberOption VenererOn;
    public static CustomNumberOption AbilityCooldown;
    public static CustomNumberOption AbilityDuration;
    public static CustomNumberOption SprintSpeed;
    public static CustomNumberOption FreezeSpeed;


    public static CustomHeaderOption ImpostorKillingRoles;

    public static CustomNumberOption BomberOn;
    public static CustomNumberOption MaxKillsInDetonation;
    public static CustomNumberOption DetonateDelay;
    public static CustomNumberOption DetonateRadius;
    public static CustomToggleOption BomberVent;

    public static CustomNumberOption TraitorOn;
    public static CustomNumberOption LatestSpawn;
    public static CustomToggleOption NeutralKillingStopsTraitor;

    public static CustomNumberOption WarlockOn;
    public static CustomNumberOption ChargeUpDuration;
    public static CustomNumberOption ChargeUseDuration;


    public static CustomHeaderOption ImpostorSupportRoles;

    public static CustomNumberOption BlackmailerOn;
    public static CustomNumberOption BlackmailCooldown;

    public static CustomNumberOption JanitorOn;

    public static CustomNumberOption MinerOn;
    public static CustomNumberOption MineCooldown;

    public static CustomNumberOption UndertakerOn;
    public static CustomNumberOption DragCooldown;
    public static CustomNumberOption UndertakerDragSpeed;
    public static CustomToggleOption UndertakerVent;
    public static CustomToggleOption UndertakerVentWithBody;


    public static CustomHeaderOption CrewmateModifiers;

    public static CustomNumberOption AftermathOn;

    public static CustomNumberOption BaitOn;
    public static CustomNumberOption BaitMinDelay;
    public static CustomNumberOption BaitMaxDelay;

    public static CustomNumberOption DiseasedOn;
    public static CustomNumberOption DiseasedKillMultiplier;

    public static CustomNumberOption FrostyOn;
    public static CustomNumberOption ChillDuration;
    public static CustomNumberOption ChillStartSpeed;

    public static CustomNumberOption MultitaskerOn;

    public static CustomNumberOption TorchOn;


    public static CustomHeaderOption GlobalModifiers;

    public static CustomNumberOption ButtonBarryOn;

    public static CustomNumberOption FlashOn;
    public static CustomNumberOption FlashSpeed;

    public static CustomNumberOption GiantOn;
    public static CustomNumberOption GiantSlow;

    public static CustomNumberOption LoversOn;
    public static CustomToggleOption BothLoversDie;
    public static CustomNumberOption LovingImpPercent;
    public static CustomToggleOption NeutralLovers;

    public static CustomNumberOption RadarOn;

    public static CustomNumberOption SleuthOn;

    public static CustomNumberOption TiebreakerOn;


    public static CustomHeaderOption ImpostorModifiers;

    public static CustomNumberOption DisperserOn;

    public static CustomNumberOption DoubleShotOn;

    public static CustomNumberOption UnderdogOn;
    public static CustomNumberOption UnderdogKillBonus;
    public static CustomToggleOption UnderdogIncreasedKC;


    public static CustomHeaderOption MapSettings;
    public static CustomToggleOption RandomMapEnabled;
    public static CustomNumberOption RandomMapSkeld;
    public static CustomNumberOption RandomMapMira;
    public static CustomNumberOption RandomMapPolus;
    public static CustomNumberOption RandomMapAirship;
    public static CustomNumberOption RandomMapFungle;
    public static CustomNumberOption RandomMapSubmerged;
    public static CustomToggleOption AutoAdjustSettings;
    public static CustomToggleOption SmallMapHalfVision;
    public static CustomNumberOption SmallMapDecreasedCooldown;
    public static CustomNumberOption LargeMapIncreasedCooldown;
    public static CustomNumberOption SmallMapIncreasedShortTasks;
    public static CustomNumberOption SmallMapIncreasedLongTasks;
    public static CustomNumberOption LargeMapDecreasedShortTasks;
    public static CustomNumberOption LargeMapDecreasedLongTasks;

    public static CustomHeaderOption CustomGameSettings;
    public static CustomToggleOption ColourblindComms;
    public static CustomToggleOption ImpostorSeeRoles;
    public static CustomToggleOption DeadSeeRoles;
    public static CustomNumberOption InitialCooldowns;
    public static CustomToggleOption ParallelMedScans;
    public static CustomStringOption SkipButtonDisable;
    public static CustomToggleOption HiddenRoles;
    public static CustomToggleOption FirstDeathShield;
    public static CustomToggleOption NeutralEvilWinEndsGame;

    public static CustomHeaderOption BetterPolusSettings;
    public static CustomToggleOption VentImprovements;
    public static CustomToggleOption VitalsLab;
    public static CustomToggleOption ColdTempDeathValley;
    public static CustomToggleOption WifiChartCourseSwap;

    public static CustomHeaderOption GameModeSettings;
    public static CustomStringOption GameMode;

    public static CustomHeaderOption ClassicSettings;
    public static CustomNumberOption MinNeutralBenignRoles;
    public static CustomNumberOption MaxNeutralBenignRoles;
    public static CustomNumberOption MinNeutralEvilRoles;
    public static CustomNumberOption MaxNeutralEvilRoles;
    public static CustomNumberOption MinNeutralKillingRoles;
    public static CustomNumberOption MaxNeutralKillingRoles;

    public static CustomHeaderOption AllAnySettings;
    public static CustomToggleOption RandomNumberImps;

    public static CustomHeaderOption KillingOnlySettings;
    public static CustomNumberOption NeutralRoles;
    public static CustomNumberOption VeteranCount;
    public static CustomNumberOption VigilanteCount;
    public static CustomToggleOption AddArsonist;
    public static CustomToggleOption AddPlaguebearer;

    public static CustomHeaderOption CultistSettings;
    public static CustomNumberOption MayorCultistOn;
    public static CustomNumberOption SeerCultistOn;
    public static CustomNumberOption SheriffCultistOn;
    public static CustomNumberOption SurvivorCultistOn;
    public static CustomNumberOption NumberOfSpecialRoles;
    public static CustomNumberOption MaxChameleons;
    public static CustomNumberOption MaxEngineers;
    public static CustomNumberOption MaxInvestigators;
    public static CustomNumberOption MaxMystics;
    public static CustomNumberOption MaxSnitches;
    public static CustomNumberOption MaxSpies;
    public static CustomNumberOption MaxTransporters;
    public static CustomNumberOption MaxVigilantes;
    public static CustomNumberOption WhisperCooldown;
    public static CustomNumberOption IncreasedCooldownPerWhisper;
    public static CustomNumberOption WhisperRadius;
    public static CustomNumberOption ConversionPercentage;
    public static CustomNumberOption DecreasedPercentagePerConversion;
    public static CustomNumberOption ReviveCooldown;
    public static CustomNumberOption IncreasedCooldownPerRevive;
    public static CustomNumberOption MaxReveals;

    public static CustomHeaderOption TaskTrackingSettings;
    public static CustomToggleOption SeeTasksDuringRound;
    public static CustomToggleOption SeeTasksDuringMeeting;
    public static CustomToggleOption SeeTasksWhenDead;

    public static CustomHeaderOption Assassin;
    public static CustomNumberOption NumberOfImpostorAssassins;
    public static CustomNumberOption NumberOfNeutralAssassins;
    public static CustomToggleOption AmneTurnImpAssassin;
    public static CustomToggleOption AmneTurnNeutAssassin;
    public static CustomToggleOption TraitorCanAssassin;
    public static CustomNumberOption AssassinKills;
    public static CustomToggleOption AssassinMultiKill;
    public static CustomToggleOption AssassinCrewmateGuess;
    public static CustomToggleOption AssassinGuessNeutralBenign;
    public static CustomToggleOption AssassinGuessNeutralEvil;
    public static CustomToggleOption AssassinGuessNeutralKilling;
    public static CustomToggleOption AssassinGuessImpostors;
    public static CustomToggleOption AssassinGuessModifiers;
    public static CustomToggleOption AssassinGuessLovers;
    public static CustomToggleOption AssassinateAfterVoting;

    public static string cs(Color c, string s)
    {
        return string.Format("<color=#{0:X2}{1:X2}{2:X2}{3:X2}>{4}</color>", ToByte(c.r), ToByte(c.g), ToByte(c.b), ToByte(c.a), s.Translate());
    }

    private static byte ToByte(float f)
    {
        f = Mathf.Clamp01(f);
        return (byte)(f * 255);
    }

    public static Func<object, string> PercentFormat { get; } = value => $"{value:0}%";
    private static Func<object, string> CooldownFormat { get; } = value => $"{value:0.0#}s";
    private static Func<object, string> MultiplierFormat { get; } = value => $"{value:0.0#}x";


    public static void GenerateAll()
    {
        var num = 0;

        CrewInvestigativeRoles = new CustomHeaderOption(num++, MultiMenu.crewmate, "option.header.CrewInvestigativeRoles");


        AurialOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Aurial, "roleName.main.aurial"), 0f, 0f, 100f,
            10f,
            PercentFormat);
        RadiateRange =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.aurial.RadiateRange", 1f, 0.25f, 5f, 0.25f, MultiplierFormat);
        RadiateCooldown =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.aurial.RadiateCooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
        RadiateInvis =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.aurial.RadiateInvis", 10f, 0f, 15f, 1f, CooldownFormat);
        RadiateCount =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.aurial.RadiateCount", 3, 1, 5, 1);
        RadiateSucceedChance =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.aurial.RadiateSucceedChance", 100f, 0f, 100f, 10f,
                PercentFormat);

        DetectiveOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Detective, "roleName.main.detective"), 0f, 0f,
                    100f, 10f,
                    PercentFormat, true);
        ExamineCooldown =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.detective.ExamineCooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
        DetectiveReportOn = new CustomToggleOption(num++, MultiMenu.crewmate, "option.detective.DetectiveReportOn");
        DetectiveRoleDuration =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.detective.DetectiveRoleDuration", 15f, 0f, 60f, 2.5f,
                CooldownFormat);
        DetectiveFactionDuration =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.detective.DetectiveFactionDuration", 30f, 0f, 60f,
                2.5f,
                CooldownFormat);
        CanDetectLastKiller = new CustomToggleOption(num++, MultiMenu.crewmate, "option.detective.CanDetectLastKiller", false);

        HaunterOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Haunter, "roleName.main.haunter"), 0f, 0f, 100f,
            10f,
            PercentFormat, true);
        HaunterTasksRemainingClicked =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.haunter.HaunterTasksRemainingClicked", 5, 1, 15,
                1);
        HaunterTasksRemainingAlert =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.haunter.HaunterTasksRemainingAlert", 1, 1, 5, 1);
        HaunterRevealsNeutrals =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.haunter.HaunterRevealsNeutrals");
        HaunterCanBeClickedBy = new CustomStringOption(num++, MultiMenu.crewmate, "option.haunter.HaunterCanBeClickedBy",
            new[] { "option.haunter.HaunterCanBeClickedBy.text1", "option.haunter.HaunterCanBeClickedBy.text2", "option.haunter.HaunterCanBeClickedBy.text3" });

        InvestigatorOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Investigator, "roleName.main.investigator"), 0f,
            0f, 100f, 10f,
            PercentFormat, true);
        FootprintSize = new CustomNumberOption(num++, MultiMenu.crewmate, "option.investigator.FootprintSize", 4f, 1f, 10f, 1f);
        FootprintInterval =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.investigator.FootprintInterval", 0.1f, 0.05f, 1f, 0.05f,
                CooldownFormat);
        FootprintDuration = new CustomNumberOption(num++, MultiMenu.crewmate, "option.investigator.FootprintDuration", 10f, 1f, 15f, 0.5f,
            CooldownFormat);
        AnonymousFootPrint = new CustomToggleOption(num++, MultiMenu.crewmate, "option.investigator.AnonymousFootPrint");
        VentFootprintVisible = new CustomToggleOption(num++, MultiMenu.crewmate, "option.investigator.VentFootprintVisible");

        MysticOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Mystic, "roleName.main.mystic"), 0f, 0f, 100f,
            10f,
            PercentFormat, true);
        MysticArrowDuration =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.mystic.MysticArrowDuration", 0.1f, 0f, 1f, 0.05f,
                CooldownFormat);

        OracleOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Oracle, "roleName.main.oracle"), 0f, 0f, 100f,
            10f,
            PercentFormat, true);
        ConfessCooldown =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.oracle.ConfessCooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
        RevealAccuracy = new CustomNumberOption(num++, MultiMenu.crewmate, "option.oracle.RevealAccuracy", 80f, 0f, 100f, 10f,
            PercentFormat);
        NeutralBenignShowsEvil =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.oracle.NeutralBenignShowsEvil");
        NeutralEvilShowsEvil =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.oracle.NeutralEvilShowsEvil");
        NeutralKillingShowsEvil =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.oracle.NeutralKillingShowsEvil");

        SeerOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Seer, "roleName.main.seer"), 0f, 0f, 100f, 10f,
            PercentFormat, true);
        SeerCooldown =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.seer.SeerCooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
        CrewKillingRed =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.seer.CrewKillingRed");
        NeutBenignRed =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.seer.NeutBenignRed");
        NeutEvilRed =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.seer.NeutEvilRed");
        NeutKillingRed =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.seer.NeutKillingRed");
        TraitorColourSwap =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.seer.TraitorColourSwap");

        SnitchOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Snitch, "roleName.main.snitch"), 0f, 0f, 100f,
            10f,
            PercentFormat, true);
        SnitchSeesNeutrals = new CustomToggleOption(num++, MultiMenu.crewmate, "option.snitch.SnitchSeesNeutrals");
        SnitchTasksRemaining =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.snitch.SnitchTasksRemaining", 1, 1, 5, 1);
        SnitchSeesImpInMeeting = new CustomToggleOption(num++, MultiMenu.crewmate, "option.snitch.SnitchSeesImpInMeeting");
        SnitchSeesTraitor = new CustomToggleOption(num++, MultiMenu.crewmate, "option.snitch.SnitchSeesTraitor");

        SpyOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Spy, "roleName.main.spy"), 0f, 0f, 100f, 10f,
            PercentFormat, true);
        WhoSeesDead = new CustomStringOption(num++, MultiMenu.crewmate, "option.spy.WhoSeesDead",
            new[] { "option.spy.WhoSeesDead.text1", "option.spy.WhoSeesDead.text2", "option.spy.WhoSeesDead.text3", "option.spy.WhoSeesDead.text4" });

        TrackerOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Tracker, "roleName.main.tracker"), 0f, 0f, 100f,
            10f,
            PercentFormat, true);
        UpdateInterval =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.tracker.UpdateInterval", 5f, 0.5f, 15f, 0.5f,
                CooldownFormat);
        TrackCooldown =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.tracker.TrackCooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
        ResetOnNewRound =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.tracker.ResetOnNewRound");
        MaxTracks = new CustomNumberOption(num++, MultiMenu.crewmate, "option.tracker.MaxTracks", 5, 1, 15,
            1);

        TrapperOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Trapper, "roleName.main.trapper"), 0f, 0f, 100f,
            10f,
            PercentFormat, true);
        MinAmountOfTimeInTrap =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.trapper.MinAmountOfTimeInTrap", 1f, 0f, 15f,
                0.5f, CooldownFormat);
        TrapCooldown =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.trapper.TrapCooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);
        TrapsRemoveOnNewRound =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.trapper.TrapsRemoveOnNewRound");
        MaxTraps =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.trapper.MaxTraps", 5, 1, 15, 1);
        TrapSize =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.trapper.TrapSize", 0.25f, 0.05f, 1f, 0.05f, MultiplierFormat);
        MinAmountOfPlayersInTrap =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.trapper.MinAmountOfPlayersInTrap", 3, 1,
                5, 1);

        CrewKillingRoles = new CustomHeaderOption(num++, MultiMenu.crewmate, "option.header.CrewKillingRoles");
        SheriffOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Sheriff, "roleName.main.sheriff"), 0f, 0f, 100f,
                    10f,
                    PercentFormat);
        SheriffKillOther =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.sheriff.SheriffKillOther");
        SheriffKillsDoomsayer =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.sheriff.SheriffKillsDoomsayer");
        SheriffKillsExecutioner =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.sheriff.SheriffKillsExecutioner");
        SheriffKillsJester =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.sheriff.SheriffKillsJester");
        SheriffKillsArsonist =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.sheriff.SheriffKillsArsonist");
        SheriffKillsGlitch =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.sheriff.SheriffKillsGlitch");
        SheriffKillsJuggernaut =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.sheriff.SheriffKillsJuggernaut");
        SheriffKillsPlaguebearer =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.sheriff.SheriffKillsPlaguebearer");
        SheriffKillsVampire =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.sheriff.SheriffKillsVampire");
        SheriffKillsWerewolf =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.sheriff.SheriffKillsWerewolf");
        SheriffKillCd =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.sheriff.SheriffKillCd", 25f, 10f, 40f, 2.5f,
                CooldownFormat);
        SheriffBodyReport = new CustomToggleOption(num++, MultiMenu.crewmate, "option.sheriff.SheriffBodyReport");

        VampireHunterOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.VampireHunter, "roleName.main.vampirehunter"),
            0f, 0f, 100f, 10f,
            PercentFormat, true);
        StakeCooldown =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.vampirehunter.StakeCooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
        MaxFailedStakesPerGame =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.vampirehunter.MaxFailedStakesPerGame", 5, 1, 15, 1);
        CanStakeRoundOne = new CustomToggleOption(num++, MultiMenu.crewmate, "option.vampirehunter.CanStakeRoundOne");
        SelfKillAfterFinalStake = new CustomToggleOption(num++, MultiMenu.crewmate,
            "option.vampirehunter.SelfKillAfterFinalStake");
        BecomeOnVampDeaths =
            new CustomStringOption(num++, MultiMenu.crewmate, "option.vampirehunter.BecomeOnVampDeaths",
                new[] { "roleName.main.crewmate", "roleName.main.sheriff", "roleName.main.veteran", "roleName.main.vigilante" });

        VeteranOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Veteran, "roleName.main.veteran"), 0f, 0f, 100f,
                    10f,
                    PercentFormat, true);
        KilledOnAlert =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.veteran.KilledOnAlert", false);
        AlertCooldown =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.veteran.AlertCooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
        AlertDuration =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.veteran.AlertDuration", 10f, 5f, 15f, 1f, CooldownFormat);
        MaxAlerts = new CustomNumberOption(num++, MultiMenu.crewmate, "option.veteran.MaxAlerts", 5, 1, 15, 1);

        VigilanteOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Vigilante, "roleName.main.vigilante"), 0f, 0f,
            100f, 10f,
            PercentFormat, true);
        VigilanteKills = new CustomNumberOption(num++, MultiMenu.crewmate, "option.vigilante.VigilanteKills", 1, 1, 15, 1);
        VigilanteMultiKill = new CustomToggleOption(num++, MultiMenu.crewmate,
            "option.vigilante.VigilanteMultiKill", false);
        VigilanteGuessNeutralBenign = new CustomToggleOption(num++, MultiMenu.crewmate,
            "option.vigilante.VigilanteGuessNeutralBenign", false);
        VigilanteGuessNeutralEvil =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.vigilante.VigilanteGuessNeutralEvil", false);
        VigilanteGuessNeutralKilling = new CustomToggleOption(num++, MultiMenu.crewmate,
            "option.vigilante.VigilanteGuessNeutralKilling", false);
        VigilanteGuessLovers = new CustomToggleOption(num++, MultiMenu.crewmate, "option.vigilante.VigilanteGuessLovers", false);
        VigilanteAfterVoting =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.vigilante.VigilanteAfterVoting", false);

        CrewProtectiveRoles = new CustomHeaderOption(num++, MultiMenu.crewmate, "option.header.CrewProtectiveRoles");

        AltruistOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Altruist, "roleName.main.altruist"), 0f, 0f,
            100f, 10f,
            PercentFormat);
        ReviveDuration =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.altruist.ReviveDuration", 10f, 1f, 15f, 1f,
                CooldownFormat);
        AltruistTargetBody =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.altruist.AltruistTargetBody", false);

        MedicOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Medic, "roleName.main.medic"), 0f, 0f, 100f, 10f,
            PercentFormat, true);
        ShowShielded =
            new CustomStringOption(num++, MultiMenu.crewmate, "option.medic.ShowShielded",
                new[] { "option.medic.ShowShielded.text1", "option.medic.ShowShielded.text2", "option.medic.ShowShielded.text3", "option.medic.ShowShielded.text4" });
        WhoGetsNotification =
            new CustomStringOption(num++, MultiMenu.crewmate, "option.medic.WhoGetsNotification",
                new[] { "option.medic.WhoGetsNotification.text1", "option.medic.WhoGetsNotification.text2", "option.medic.WhoGetsNotification.text3", "option.medic.WhoGetsNotification.text4" });
        ShieldBreaks = new CustomToggleOption(num++, MultiMenu.crewmate, "option.medic.ShieldBreaks", false);
        MedicReportSwitch = new CustomToggleOption(num++, MultiMenu.crewmate, "option.medic.MedicReportSwitch");
        MedicReportNameDuration =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.medic.MedicReportNameDuration", 0f, 0f, 60f, 2.5f,
                CooldownFormat);
        MedicReportColorDuration =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.medic.MedicReportColorDuration", 15f, 0f, 60f,
                2.5f,
                CooldownFormat);

        CrewSupportRoles = new CustomHeaderOption(num++, MultiMenu.crewmate, "option.header.CrewSupportRoles");
        EngineerOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Engineer, "roleName.main.engineer"), 0f, 0f,
            100f, 10f,
            PercentFormat);
        MaxFixes =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.engineer.MaxFixes", 5, 1, 15, 1);

        ImitatorOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Imitator, "roleName.main.imitator"), 0f, 0f,
            100f, 10f,
            PercentFormat, true);
        MayorOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Mayor, "roleName.main.mayor"), 0f, 0f, 100f, 10f,
            PercentFormat, true);

        MediumOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Medium, "roleName.main.medium"), 0f, 0f, 100f,
            10f,
            PercentFormat, true);
        MediateCooldown =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.medium.MediateCooldown", 10f, 1f, 15f, 1f, CooldownFormat);
        ShowMediatePlayer =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.medium.ShowMediatePlayer");
        ShowMediumToDead =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.medium.ShowMediumToDead");
        DeadRevealed =
            new CustomStringOption(num++, MultiMenu.crewmate, "option.medium.DeadRevealed",
                new[] { "option.medium.DeadRevealed.text1", "option.medium.DeadRevealed.text2", "option.medium.DeadRevealed.text3" });

        ProsecutorOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Prosecutor, "roleName.main.prosecutor"), 0f, 0f,
            100f, 10f,
            PercentFormat, true);
        ProsDiesOnIncorrectPros =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.prosecutor.ProsDiesOnIncorrectPros", false);

        SwapperOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Swapper, "roleName.main.swapper"), 0f, 0f, 100f,
                    10f,
                    PercentFormat, true);
        SwapperButton =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.swapper.SwapperButton");

        TransporterOn = new CustomNumberOption(num++, MultiMenu.crewmate, cs(Colors.Transporter, "roleName.main.transporter"), 0f,
            0f, 100f, 10f,
            PercentFormat, true);
        TransportCooldown =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.transporter.TransportCooldown", 25f, 10f, 60f, 2.5f,
                CooldownFormat);
        TransportMaxUses =
            new CustomNumberOption(num++, MultiMenu.crewmate, "option.transporter.TransportMaxUses", 5, 1, 15, 1);
        TransporterVitals =
            new CustomToggleOption(num++, MultiMenu.crewmate, "option.transporter.TransporterVitals", false);

        NeutralBenignRoles = new CustomHeaderOption(num++, MultiMenu.neutral, "option.header.NeutralBenignRoles");
        AmnesiacOn = new CustomNumberOption(num++, MultiMenu.neutral, cs(Colors.Amnesiac, "roleName.main.amnesiac"), 0f, 0f, 100f,
            10f,
            PercentFormat);
        RememberArrows =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.amnesiac.RememberArrows", false);
        RememberArrowDelay =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.amnesiac.RememberArrowDelay", 5f, 0f, 15f, 1f,
                CooldownFormat);

        GuardianAngelOn = new CustomNumberOption(num++, MultiMenu.neutral, cs(Colors.GuardianAngel, "roleName.main.guardianangel"),
            0f, 0f, 100f, 10f,
            PercentFormat, true);
        ProtectCd =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.guardianangel.ProtectCd", 25f, 10f, 60f, 2.5f, CooldownFormat);
        ProtectDuration =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.guardianangel.ProtectDuration", 10f, 5f, 15f, 1f, CooldownFormat);
        ProtectKCReset =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.guardianangel.ProtectKCReset", 2.5f, 0f, 15f, 0.5f,
                CooldownFormat);
        MaxProtects =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.guardianangel.MaxProtects", 5, 1, 15, 1);
        ShowProtect =
            new CustomStringOption(num++, MultiMenu.neutral, "option.guardianangel.ShowProtect",
                new[] { "option.guardianangel.ShowProtect.text1", "roleName.main.guardianangel", "option.guardianangel.ShowProtect.text2", "option.guardianangel.ShowProtect.text3" });
        GaOnTargetDeath = new CustomStringOption(num++, MultiMenu.neutral, "option.guardianangel.GaOnTargetDeath",
            new[] { "roleName.main.crewmate", "roleName.main.amnesiac", "roleName.main.survivor", "roleName.main.jester" });
        GATargetKnows =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.guardianangel.GATargetKnows", false);
        GAKnowsTargetRole =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.guardianangel.GAKnowsTargetRole", false);
        EvilTargetPercent = new CustomNumberOption(num++, MultiMenu.neutral, "option.guardianangel.EvilTargetPercent", 20f, 0f, 100f,
            10f,
            PercentFormat);

        SurvivorOn = new CustomNumberOption(num++, MultiMenu.neutral, cs(Colors.Survivor, "roleName.main.survivor"), 0f, 0f, 100f,
            10f,
            PercentFormat, true);
        VestCd =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.survivor.VestCd", 25f, 10f, 60f, 2.5f, CooldownFormat);
        VestDuration =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.survivor.VestDuration", 10f, 5f, 15f, 1f, CooldownFormat);
        VestKCReset =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.survivor.VestKCReset", 2.5f, 0f, 15f, 0.5f,
                CooldownFormat);
        MaxVests =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.survivor.MaxVests", 5, 1, 15, 1);

        NeutralEvilRoles = new CustomHeaderOption(num++, MultiMenu.neutral, "option.header.NeutralEvilRoles");
        DoomsayerOn = new CustomNumberOption(num++, MultiMenu.neutral, cs(Colors.Doomsayer, "roleName.main.doomsayer"), 0f, 0f,
            100f, 10f,
            PercentFormat);
        ObserveCooldown =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.doomsayer.ObserveCooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
        DoomsayerGuessNeutralBenign =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.doomsayer.DoomsayerGuessNeutralBenign", false);
        DoomsayerGuessNeutralEvil =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.doomsayer.DoomsayerGuessNeutralEvil", false);
        DoomsayerGuessNeutralKilling = new CustomToggleOption(num++, MultiMenu.neutral,
            "option.doomsayer.DoomsayerGuessNeutralKilling", false);
        DoomsayerGuessImpostors =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.doomsayer.DoomsayerGuessImpostors", false);
        DoomsayerAfterVoting =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.doomsayer.DoomsayerAfterVoting", false);
        DoomsayerGuessesToWin =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.doomsayer.DoomsayerGuessesToWin", 3, 1, 5, 1);

        ExecutionerOn = new CustomNumberOption(num++, MultiMenu.neutral, cs(Colors.Executioner, "roleName.main.executioner"), 0f, 0f,
                100f, 10f,
                PercentFormat, true);
        OnTargetDead = new CustomStringOption(num++, MultiMenu.neutral, "option.executioner.OnTargetDead",
            new[] { "roleName.main.crewmate", "roleName.main.amnesiac", "roleName.main.survivor", "roleName.main.jester" });
        ExecutionerButton =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.executioner.ExecutionerButton");
        ExecutionerTorment =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.executioner.ExecutionerTorment", false);

        JesterOn = new CustomNumberOption(num++, MultiMenu.neutral, cs(Colors.Jester, "roleName.main.jester"), 0f, 0f, 100f,
            10f,
            PercentFormat, true);
        JesterButton =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.jester.JesterButton");
        JesterVent =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.jester.JesterVent", false);
        JesterImpVision =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.jester.JesterImpVision", false);
        JesterHaunt =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.jester.JesterHaunt", false);

        PhantomOn = new CustomNumberOption(num++, MultiMenu.neutral, cs(Colors.Phantom, "roleName.main.phantom"), 0f, 0f, 100f,
                    10f,
                    PercentFormat, true);
        PhantomTasksRemaining =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.phantom.PhantomTasksRemaining", 5, 1, 15,
                1);
        PhantomSpook =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.phantom.PhantomSpook", false);

        ArsonistOn = new CustomNumberOption(num++, MultiMenu.neutral, cs(Colors.Arsonist, "roleName.main.arsonist"), 0f, 0f, 100f,
            10f,
            PercentFormat, true);
        DouseCooldown =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.arsonist.DouseCooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
        MaxDoused =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.arsonist.MaxDoused", 5, 1, 15, 1);
        ArsoImpVision =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.arsonist.ArsoImpVision", false);
        IgniteCdRemoved =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.arsonist.IgniteCdRemoved", false);

        PlaguebearerOn = new CustomNumberOption(num++, MultiMenu.neutral, cs(Colors.Plaguebearer, "roleName.main.plaguebearer"), 0f,
            0f, 100f, 10f,
            PercentFormat, true);
        InfectCooldown =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.plaguebearer.InfectCooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
        PestKillCooldown =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.plaguebearer.PestKillCooldown", 25f, 10f, 60f, 2.5f,
                CooldownFormat);
        PestVent =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.plaguebearer.PestVent", false);

        GlitchOn = new CustomNumberOption(num++, MultiMenu.neutral, cs(Colors.Glitch, "roleName.main.glitch"), 0f, 0f, 100f,
            10f,
            PercentFormat, true);
        MimicCooldownOption = new CustomNumberOption(num++, MultiMenu.neutral, "option.glitch.MimicCooldown", 25f, 10f, 60f, 2.5f,
            CooldownFormat);
        MimicDurationOption =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.glitch.MimicDuration", 10f, 1f, 15f, 1f, CooldownFormat);
        HackCooldownOption = new CustomNumberOption(num++, MultiMenu.neutral, "option.glitch.HackCooldown", 25f, 10f, 60f, 2.5f,
            CooldownFormat);
        HackDurationOption =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.glitch.HackDuration", 10f, 1f, 15f, 1f, CooldownFormat);
        GlitchKillCooldownOption =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.glitch.GlitchKillCooldown", 25f, 10f, 120f, 2.5f,
                CooldownFormat);
        GlitchHackDistanceOption =
            new CustomStringOption(num++, MultiMenu.neutral, "option.glitch.GlitchHackDistance",
                new[] { "option.glitch.GlitchHackDistance.text1", "option.glitch.GlitchHackDistance.text2", "option.glitch.GlitchHackDistance.text3" });
        GlitchVent =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.glitch.GlitchVent", false);

        VampireOn = new CustomNumberOption(num++, MultiMenu.neutral, cs(Colors.Vampire, "roleName.main.vampire"), 0f, 0f, 100f,
                    10f,
                    PercentFormat, true);
        BiteCooldown =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.vampire.BiteCooldown", 25f, 10f, 60f, 2.5f,
                CooldownFormat);
        VampImpVision =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.vampire.VampImpVision", false);
        VampVent =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.vampire.VampVent", false);
        NewVampCanAssassin =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.vampire.NewVampCanAssassin", false);
        MaxVampiresPerGame =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.vampire.MaxVampiresPerGame", 2, 2, 5, 1);
        CanBiteNeutralBenign =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.vampire.CanBiteNeutralBenign", false);
        CanBiteNeutralEvil =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.vampire.CanBiteNeutralEvil", false);

        WerewolfOn = new CustomNumberOption(num++, MultiMenu.neutral, cs(Colors.Werewolf, "roleName.main.werewolf"), 0f, 0f, 100f,
            10f,
            PercentFormat, true);
        RampageCooldown =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.werewolf.RampageCooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
        RampageDuration =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.werewolf.RampageDuration", 25f, 10f, 60f, 2.5f, CooldownFormat);
        RampageKillCooldown =
            new CustomNumberOption(num++, MultiMenu.neutral, "option.werewolf.RampageKillCooldown", 10f, 0.5f, 15f, 0.5f,
                CooldownFormat);
        WerewolfVent =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.werewolf.WerewolfVent", false);

        Juggernaut =
            new CustomHeaderOption(num++, MultiMenu.neutral, cs(Colors.Juggernaut, "roleName.main.juggernaut"));
        JuggKillCooldown = new CustomNumberOption(num++, MultiMenu.neutral, "option.juggernaut.JuggKillCooldown", 25f,
            10f, 60f, 2.5f, CooldownFormat);
        ReducedKCdPerKill = new CustomNumberOption(num++, MultiMenu.neutral, "option.juggernaut.ReducedKCdPerKill", 5f, 2.5f,
            10f, 2.5f, CooldownFormat);
        JuggVent =
            new CustomToggleOption(num++, MultiMenu.neutral, "option.juggernaut.JuggVent", false);

        ImpostorConcealingRoles = new CustomHeaderOption(num++, MultiMenu.imposter, "option.header.ImpostorConcealingRoles");

        EscapistOn = new CustomNumberOption(num++, MultiMenu.imposter, cs(Colors.Impostor, "roleName.main.escapist"), 0f, 0f,
            100f, 10f,
            PercentFormat);
        EscapeCooldown =
            new CustomNumberOption(num++, MultiMenu.imposter, "option.escapist.EscapeCooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
        EscapistVent =
            new CustomToggleOption(num++, MultiMenu.imposter, "option.escapist.EscapistVent", false);

        GrenadierOn = new CustomNumberOption(num++, MultiMenu.imposter, cs(Colors.Impostor, "roleName.main.grenadier"), 0f, 0f,
            100f, 10f,
            PercentFormat, true);
        GrenadeCooldown =
            new CustomNumberOption(num++, MultiMenu.imposter, "option.grenadier.GrenadeCooldown", 25f, 10f, 60f, 2.5f,
                CooldownFormat);
        GrenadeDuration =
            new CustomNumberOption(num++, MultiMenu.imposter, "option.grenadier.GrenadeDuration", 10f, 5f, 15f, 1f,
                CooldownFormat);
        FlashRadius =
            new CustomNumberOption(num++, MultiMenu.imposter, "option.grenadier.FlashRadius", 1f, 0.25f, 5f, 0.25f, MultiplierFormat);
        GrenadierIndicators =
            new CustomToggleOption(num++, MultiMenu.imposter, "option.grenadier.GrenadierIndicators", false);
        GrenadierVent =
            new CustomToggleOption(num++, MultiMenu.imposter, "option.grenadier.GrenadierVent", false);

        MorphlingOn = new CustomNumberOption(num++, MultiMenu.imposter, cs(Colors.Impostor, "roleName.main.morphling"), 0f, 0f,
            100f, 10f,
            PercentFormat, true);
        MorphlingCooldown =
            new CustomNumberOption(num++, MultiMenu.imposter, "option.morphling.MorphlingCooldown", 25f, 10f, 60f, 2.5f,
                CooldownFormat);
        MorphlingDuration =
            new CustomNumberOption(num++, MultiMenu.imposter, "option.morphling.MorphlingDuration", 10f, 5f, 15f, 1f, CooldownFormat);
        MorphlingVent =
            new CustomToggleOption(num++, MultiMenu.imposter, "option.morphling.MorphlingVent", false);

        SwooperOn = new CustomNumberOption(num++, MultiMenu.imposter, cs(Colors.Impostor, "roleName.main.swooper"), 0f, 0f, 100f,
                10f,
                PercentFormat, true);
        SwoopCooldown =
            new CustomNumberOption(num++, MultiMenu.imposter, "option.swooper.SwoopCooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
        SwoopDuration =
            new CustomNumberOption(num++, MultiMenu.imposter, "option.swooper.SwoopDuration", 10f, 5f, 15f, 1f, CooldownFormat);
        SwooperVent =
            new CustomToggleOption(num++, MultiMenu.imposter, "option.swooper.SwooperVent", false);

        VenererOn = new CustomNumberOption(num++, MultiMenu.imposter, cs(Colors.Impostor, "roleName.main.venerer"), 0f, 0f, 100f,
            10f,
            PercentFormat, true);
        AbilityCooldown =
            new CustomNumberOption(num++, MultiMenu.imposter, "option.venerer.AbilityCooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
        AbilityDuration =
            new CustomNumberOption(num++, MultiMenu.imposter, "option.venerer.AbilityDuration", 10f, 5f, 15f, 1f, CooldownFormat);
        SprintSpeed = new CustomNumberOption(num++, MultiMenu.imposter, "option.venerer.SprintSpeed", 1.25f, 1.05f, 2.5f, 0.05f,
            MultiplierFormat);
        FreezeSpeed = new CustomNumberOption(num++, MultiMenu.imposter, "option.venerer.FreezeSpeed", 0.75f, 0.25f, 1f, 0.05f,
            MultiplierFormat);

        ImpostorKillingRoles = new CustomHeaderOption(num++, MultiMenu.imposter, "Impostor Killing Roles");

        BomberOn = new CustomNumberOption(num++, MultiMenu.imposter, cs(Colors.Impostor, "roleName.main.bomber"), 0f, 0f, 100f,
            10f,
            PercentFormat,
            true);
        DetonateDelay =
            new CustomNumberOption(num++, MultiMenu.imposter, "option.bomber.DetonateDelay", 5f, 1f, 15f, 1f, CooldownFormat);
        MaxKillsInDetonation =
            new CustomNumberOption(num++, MultiMenu.imposter, "option.bomber.MaxKillsInDetonation", 5, 1, 15, 1);
        DetonateRadius =
            new CustomNumberOption(num++, MultiMenu.imposter, "option.bomber.DetonateRadius", 0.25f, 0.05f, 1f, 0.05f,
                MultiplierFormat);
        BomberVent =
            new CustomToggleOption(num++, MultiMenu.imposter, "option.bomber.BomberVent", false);

        TraitorOn = new CustomNumberOption(num++, MultiMenu.imposter, cs(Colors.Impostor, "roleName.main.traitor"), 0f, 0f, 100f,
            10f,
            PercentFormat, true);
        LatestSpawn = new CustomNumberOption(num++, MultiMenu.imposter, "option.traitor.LatestSpawn",
            5, 3, 15, 1);
        NeutralKillingStopsTraitor =
            new CustomToggleOption(num++, MultiMenu.imposter, "option.traitor.NeutralKillingStopsTraitor", false);

        WarlockOn = new CustomNumberOption(num++, MultiMenu.imposter, cs(Colors.Impostor, "roleName.main.warlock"), 0f, 0f, 100f,
                            10f,
                            PercentFormat, true);
        ChargeUpDuration =
            new CustomNumberOption(num++, MultiMenu.imposter, "option.warlock.ChargeUpDuration", 25f, 10f, 60f, 2.5f,
                CooldownFormat);
        ChargeUseDuration =
            new CustomNumberOption(num++, MultiMenu.imposter, "option.warlock.ChargeUseDuration", 1f, 0.05f, 5f, 0.05f,
                CooldownFormat);

        ImpostorSupportRoles = new CustomHeaderOption(num++, MultiMenu.imposter, "Impostor Support Roles");

        BlackmailerOn = new CustomNumberOption(num++, MultiMenu.imposter, cs(Colors.Impostor, "roleName.main.blackmailer"), 0f, 0f, 100f, 10f,
            PercentFormat);
        BlackmailCooldown =
    new CustomNumberOption(num++, MultiMenu.imposter, "Initial Blackmail Cooldown", 10f, 1f, 15f, 1f, CooldownFormat);

        JanitorOn = new CustomNumberOption(num++, MultiMenu.imposter, cs(Colors.Impostor, "roleName.main.janitor"), 0f, 0f, 100f, 10f,
            PercentFormat, true);
        MinerOn = new CustomNumberOption(num++, MultiMenu.imposter, cs(Colors.Impostor, "roleName.main.miner"), 0f, 0f, 100f, 10f,
            PercentFormat, true);
        MineCooldown =
    new CustomNumberOption(num++, MultiMenu.imposter, "Mine Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
        
        UndertakerOn = new CustomNumberOption(num++, MultiMenu.imposter, cs(Colors.Impostor, "roleName.main.undertaker"), 0f, 0f,
            100f, 10f,
            PercentFormat, true);
        DragCooldown = new CustomNumberOption(num++, MultiMenu.imposter, "option.undertaker.DragCooldown", 25f, 10f, 60f, 2.5f,
            CooldownFormat);
        UndertakerDragSpeed =
            new CustomNumberOption(num++, MultiMenu.imposter, "option.undertaker.UndertakerDragSpeed", 0.75f, 0.25f, 1f, 0.05f,
                MultiplierFormat);
        UndertakerVent =
            new CustomToggleOption(num++, MultiMenu.imposter, "option.undertaker.UndertakerVent", false);
        UndertakerVentWithBody =
            new CustomToggleOption(num++, MultiMenu.imposter, "option.undertaker.UndertakerVentWithBody", false);



        CrewmateModifiers = new CustomHeaderOption(num++, MultiMenu.modifiers, "Crewmate Modifiers");

        AftermathOn = new CustomNumberOption(num++, MultiMenu.modifiers, cs(Colors.Aftermath, "roleName.modifiers.aftermath"), 0f, 0f, 100f, 10f,
            PercentFormat);

        BaitOn = new CustomNumberOption(num++, MultiMenu.modifiers, cs(Colors.Bait, "roleName.modifiers.bait"), 0f, 0f, 100f, 10f,
            PercentFormat, true);
        BaitMinDelay = new CustomNumberOption(num++, MultiMenu.modifiers, "option.bait.BaitMinDelay", 0f, 0f,
            15f, 0.5f, CooldownFormat);
        BaitMaxDelay = new CustomNumberOption(num++, MultiMenu.modifiers, "option.bait.BaitMaxDelay", 1f, 0f,
            15f, 0.5f, CooldownFormat);

        DiseasedOn = new CustomNumberOption(num++, MultiMenu.modifiers, cs(Colors.Diseased, "roleName.modifiers.diseased"), 0f, 0f,
            100f, 10f,
            PercentFormat, true);
        DiseasedKillMultiplier = new CustomNumberOption(num++, MultiMenu.modifiers, "option.diseased.DiseasedKillMultiplier", 3f,
            1.5f, 5f, 0.5f, MultiplierFormat);

        FrostyOn = new CustomNumberOption(num++, MultiMenu.modifiers, cs(Colors.Frosty, "roleName.modifiers.frosty"), 0f, 0f, 100f, 10f,
    PercentFormat, true);
        ChillDuration = new CustomNumberOption(num++, MultiMenu.modifiers, "Chill Duration", 10f, 1f, 15f, 1f, CooldownFormat);
        ChillStartSpeed = new CustomNumberOption(num++, MultiMenu.modifiers, "Chill Start Speed", 0.75f, 0.25f, 0.95f, 0.05f, MultiplierFormat);

        MultitaskerOn = new CustomNumberOption(num++, MultiMenu.modifiers, cs(Colors.Multitasker, "roleName.modifiers.multitasker"), 0f, 0f, 100f, 10f,
            PercentFormat, true);

        TorchOn = new CustomNumberOption(num++, MultiMenu.modifiers, cs(Colors.Torch, "roleName.modifiers.torch"), 0f, 0f, 100f, 10f,
            PercentFormat, true);

        GlobalModifiers = new CustomHeaderOption(num++, MultiMenu.modifiers, "Global Modifiers");

        ButtonBarryOn = new CustomNumberOption(num++, MultiMenu.modifiers, cs(Colors.ButtonBarry, "roleName.modifiers.buttonbarry"), 0f, 0f, 100f, 10f,
            PercentFormat);

        FlashOn = new CustomNumberOption(num++, MultiMenu.modifiers, cs(Colors.Flash, "roleName.modifiers.flash"), 0f, 0f, 100f,
            10f,
            PercentFormat, true);
        FlashSpeed = new CustomNumberOption(num++, MultiMenu.modifiers, "option.flash.FlashSpeed", 1.25f, 1.05f, 2.5f, 0.05f,
            MultiplierFormat, true);

        GiantOn = new CustomNumberOption(num++, MultiMenu.modifiers, cs(Colors.Giant, "roleName.modifiers.giant"), 0f, 0f, 100f, 10f,
            PercentFormat,true);
        GiantSlow = new CustomNumberOption(num++, MultiMenu.modifiers, "Giant Speed", 0.75f, 0.25f, 1f, 0.05f, MultiplierFormat);

        LoversOn = new CustomNumberOption(num++, MultiMenu.modifiers, cs(Colors.Lovers, "roleName.modifiers.lover"), 0f, 0f, 100f,
            10f,
            PercentFormat, true);
        BothLoversDie = new CustomToggleOption(num++, MultiMenu.modifiers, "option.lovers.BothLoversDie");
        LovingImpPercent = new CustomNumberOption(num++, MultiMenu.modifiers, "option.lovers.LovingImpPercent", 20f, 0f,
            100f, 10f,
            PercentFormat);
        NeutralLovers = new CustomToggleOption(num++, MultiMenu.modifiers, "option.lovers.NeutralLovers");

        RadarOn = new CustomNumberOption(num++, MultiMenu.modifiers, cs(Colors.Radar, "roleName.modifiers.Radar"), 0f, 0f, 100f, 10f,
    PercentFormat, true);
        SleuthOn = new CustomNumberOption(num++, MultiMenu.modifiers, cs(Colors.Sleuth, "roleName.modifiers.Sleuth"), 0f, 0f, 100f, 10f,
            PercentFormat, true);
        TiebreakerOn = new CustomNumberOption(num++, MultiMenu.modifiers, cs(Colors.Tiebreaker, "roleName.modifiers.tiebreaker"), 0f, 0f, 100f, 10f,
            PercentFormat, true);

        ImpostorModifiers = new CustomHeaderOption(num++, MultiMenu.modifiers, "Impostor Modifiers");
        DisperserOn = new CustomNumberOption(num++, MultiMenu.modifiers, cs(Colors.Impostor, "roleName.modifiers.disperser"), 0f, 0f, 100f, 10f,
            PercentFormat);
        DoubleShotOn = new CustomNumberOption(num++, MultiMenu.modifiers, cs(Colors.Impostor, "roleName.modifiers.doubleshot"), 0f, 0f, 100f, 10f,
            PercentFormat, true);

        UnderdogOn = new CustomNumberOption(num++, MultiMenu.modifiers, cs(Colors.Impostor, "roleName.modifiers.underdog"), 0f, 0f,
            100f, 10f,
            PercentFormat, true);
        UnderdogKillBonus = new CustomNumberOption(num++, MultiMenu.modifiers, "option.underdog.UnderdogKillBonus", 5f, 2.5f, 10f,
            2.5f, CooldownFormat);
        UnderdogIncreasedKC =
            new CustomToggleOption(num++, MultiMenu.modifiers, "option.underdog.UnderdogIncreasedKC");


        GameModeSettings =
            new CustomHeaderOption(num++, MultiMenu.main, "option.main.GameModeSettings");
        GameMode = new CustomStringOption(num++, MultiMenu.main, "option.main.GameMode",
            new[] { "option.main.GameMode.text1", "option.main.GameMode.text2", "option.main.GameMode.text3", "option.main.GameMode.text4" });

        ClassicSettings =
            new CustomHeaderOption(num++, MultiMenu.main, "option.main.ClassicSettings");
        MinNeutralBenignRoles =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.MinNeutralBenignRoles", 1, 0, 3, 1);
        MaxNeutralBenignRoles =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.MaxNeutralBenignRoles", 1, 0, 3, 1);
        MinNeutralEvilRoles =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.MinNeutralEvilRoles", 1, 0, 3, 1);
        MaxNeutralEvilRoles =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.MaxNeutralEvilRoles", 1, 0, 3, 1);
        MinNeutralKillingRoles =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.MinNeutralKillingRoles", 1, 0, 5, 1);
        MaxNeutralKillingRoles =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.MaxNeutralKillingRoles", 1, 0, 5, 1);

        AllAnySettings =
            new CustomHeaderOption(num++, MultiMenu.main, "option.main.AllAnySettings");
        RandomNumberImps = new CustomToggleOption(num++, MultiMenu.main, "option.main.RandomNumberImps");

        KillingOnlySettings =
            new CustomHeaderOption(num++, MultiMenu.main, "option.main.KillingOnlySettings");
        NeutralRoles =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.NeutralRoles", 1, 0, 5, 1);
        VeteranCount =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.VeteranCount", 1, 0, 5, 1);
        VigilanteCount =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.VigilanteCount", 1, 0, 5, 1);
        AddArsonist = new CustomToggleOption(num++, MultiMenu.main, "option.main.AddArsonist");
        AddPlaguebearer = new CustomToggleOption(num++, MultiMenu.main, "option.main.AddPlaguebearer");

        CultistSettings =
            new CustomHeaderOption(num++, MultiMenu.main, "option.main.CultistSettings");
        MayorCultistOn = new CustomNumberOption(num++, MultiMenu.main, "option.main.MayorCultistOn",
            100f, 0f, 100f, 10f,
            PercentFormat);
        SeerCultistOn = new CustomNumberOption(num++, MultiMenu.main, "option.main.SeerCultistOn",
            100f, 0f, 100f, 10f,
            PercentFormat);
        SheriffCultistOn = new CustomNumberOption(num++, MultiMenu.main, "option.main.SheriffCultistOn",
            100f, 0f, 100f, 10f,
            PercentFormat);
        SurvivorCultistOn = new CustomNumberOption(num++, MultiMenu.main, "option.main.SurvivorCultistOn",
            100f, 0f, 100f, 10f,
            PercentFormat);
        NumberOfSpecialRoles =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.NumberOfSpecialRoles", 4, 0, 4, 1);
        MaxChameleons =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.MaxChameleons", 3, 0, 5, 1);
        MaxEngineers =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.MaxEngineers", 3, 0, 5, 1);
        MaxInvestigators =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.MaxInvestigators", 3, 0, 5, 1);
        MaxMystics =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.MaxMystics", 3, 0, 5, 1);
        MaxSnitches =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.MaxSnitches", 3, 0, 5, 1);
        MaxSpies =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.MaxSpies", 3, 0, 5, 1);
        MaxTransporters =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.MaxTransporters", 3, 0, 5, 1);
        MaxVigilantes =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.MaxVigilantes", 3, 0, 5, 1);
        WhisperCooldown =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.WhisperCooldown", 25f, 10f, 60f, 2.5f,
                CooldownFormat);
        IncreasedCooldownPerWhisper =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.IncreasedCooldownPerWhisper", 5f, 0f, 15f, 0.5f,
                CooldownFormat);
        WhisperRadius =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.WhisperRadius", 1f, 0.25f, 5f, 0.25f, MultiplierFormat);
        ConversionPercentage = new CustomNumberOption(num++, MultiMenu.main, "option.main.ConversionPercentage", 25f, 0f, 100f, 5f,
            PercentFormat);
        DecreasedPercentagePerConversion = new CustomNumberOption(num++, MultiMenu.main,
            "option.main.DecreasedPercentagePerConversion", 5f, 0f, 15f, 1f,
            PercentFormat);
        ReviveCooldown =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.ReviveCooldown", 25f, 10f, 60f, 2.5f,
                CooldownFormat);
        IncreasedCooldownPerRevive =
            new CustomNumberOption(num++, MultiMenu.main, "option.main.IncreasedCooldownPerRevive", 25f, 10f, 60f, 2.5f,
                CooldownFormat);
        MaxReveals = new CustomNumberOption(num++, MultiMenu.main, "option.main.MaxReveals", 5, 1, 15, 1);

        MapSettings = new CustomHeaderOption(num++, MultiMenu.main, "option.main.MapSettings");
        RandomMapEnabled = new CustomToggleOption(num++, MultiMenu.main, "option.main.RandomMapEnabled", false);
        RandomMapSkeld = new CustomNumberOption(num++, MultiMenu.main, "option.main.RandomMapSkeld", 0f, 0f, 100f, 10f, PercentFormat);
        RandomMapMira = new CustomNumberOption(num++, MultiMenu.main, "option.main.RandomMapMira", 0f, 0f, 100f, 10f, PercentFormat);
        RandomMapPolus = new CustomNumberOption(num++, MultiMenu.main, "option.main.RandomMapPolus", 0f, 0f, 100f, 10f, PercentFormat);
        RandomMapAirship = new CustomNumberOption(num++, MultiMenu.main, "option.main.RandomMapAirship", 0f, 0f, 100f, 10f, PercentFormat);
        RandomMapFungle = new CustomNumberOption(num++, MultiMenu.main, "option.main.RandomMapFungle", 0f, 0f, 100f, 10f, PercentFormat);
        RandomMapSubmerged = new CustomNumberOption(num++, MultiMenu.main, "option.main.RandomMapSubmerged", 0f, 0f, 100f, 10f, PercentFormat);
        AutoAdjustSettings = new CustomToggleOption(num++, MultiMenu.main, "option.main.AutoAdjustSettings", false);
        SmallMapHalfVision = new CustomToggleOption(num++, MultiMenu.main, "option.main.SmallMapHalfVision", false);
        SmallMapDecreasedCooldown = new CustomNumberOption(num++, MultiMenu.main, "option.main.SmallMapDecreasedCooldown", 0f, 0f, 15f, 2.5f, CooldownFormat);
        LargeMapIncreasedCooldown = new CustomNumberOption(num++, MultiMenu.main, "option.main.LargeMapIncreasedCooldown", 0f, 0f, 15f, 2.5f, CooldownFormat);
        SmallMapIncreasedShortTasks = new CustomNumberOption(num++, MultiMenu.main, "option.main.SmallMapIncreasedShortTasks", 0, 0, 5, 1);
        SmallMapIncreasedLongTasks = new CustomNumberOption(num++, MultiMenu.main, "option.main.SmallMapIncreasedLongTasks", 0, 0, 3, 1);
        LargeMapDecreasedShortTasks = new CustomNumberOption(num++, MultiMenu.main, "option.main.LargeMapDecreasedShortTasks", 0, 0, 5, 1);
        LargeMapDecreasedLongTasks = new CustomNumberOption(num++, MultiMenu.main, "option.main.LargeMapDecreasedLongTasks", 0, 0, 3, 1);

        BetterPolusSettings = new CustomHeaderOption(num++, MultiMenu.main, "option.main.BetterPolusSettings");
        VentImprovements = new CustomToggleOption(num++, MultiMenu.main, "option.main.VentImprovements", false);
        VitalsLab = new CustomToggleOption(num++, MultiMenu.main, "option.main.VitalsLab", false);
        ColdTempDeathValley = new CustomToggleOption(num++, MultiMenu.main, "option.main.ColdTempDeathValley", false);
        WifiChartCourseSwap = new CustomToggleOption(num++, MultiMenu.main, "option.main.WifiChartCourseSwap", false);

        CustomGameSettings = new CustomHeaderOption(num++, MultiMenu.main, "option.main.CustomGameSettings");
        ColourblindComms = new CustomToggleOption(num++, MultiMenu.main, "option.main.ColourblindComms", false);
        ImpostorSeeRoles = new CustomToggleOption(num++, MultiMenu.main, "option.main.ImpostorSeeRoles", false);
        DeadSeeRoles = new CustomToggleOption(num++, MultiMenu.main, "option.main.DeadSeeRoles", false);
        InitialCooldowns = new CustomNumberOption(num++, MultiMenu.main, "option.main.InitialCooldowns", 10f, 10f, 30f, 2.5f, CooldownFormat);
        ParallelMedScans = new CustomToggleOption(num++, MultiMenu.main, "option.main.ParallelMedScans", false);
        SkipButtonDisable = new CustomStringOption(num++, MultiMenu.main, "option.main.SkipButtonDisable", new[] { "No", "Emergency", "Always" });
        HiddenRoles = new CustomToggleOption(num++, MultiMenu.main, "option.main.HiddenRoles");
        FirstDeathShield = new CustomToggleOption(num++, MultiMenu.main, "option.main.FirstDeathShield", false);
        NeutralEvilWinEndsGame = new CustomToggleOption(num++, MultiMenu.main, "option.main.NeutralEvilWinEndsGame");

        TaskTrackingSettings = new CustomHeaderOption(num++, MultiMenu.main, "option.main.TaskTrackingSettings");
        SeeTasksDuringRound = new CustomToggleOption(num++, MultiMenu.main, "option.main.SeeTasksDuringRound", false);
        SeeTasksDuringMeeting = new CustomToggleOption(num++, MultiMenu.main, "option.main.SeeTasksDuringMeeting", false);
        SeeTasksWhenDead = new CustomToggleOption(num++, MultiMenu.main, "option.main.SeeTasksWhenDead");

        Assassin = new CustomHeaderOption(num++, MultiMenu.imposter, "option.imposter.Assassin");
        NumberOfImpostorAssassins = new CustomNumberOption(num++, MultiMenu.imposter, "option.imposter.NumberOfImpostorAssassins", 1, 0, 4, 1);
        NumberOfNeutralAssassins = new CustomNumberOption(num++, MultiMenu.imposter, "option.imposter.NumberOfNeutralAssassins", 1, 0, 5, 1);
        AmneTurnImpAssassin = new CustomToggleOption(num++, MultiMenu.imposter, "option.imposter.AmneTurnImpAssassin", false);
        AmneTurnNeutAssassin = new CustomToggleOption(num++, MultiMenu.imposter, "option.imposter.AmneTurnNeutAssassin", false);
        TraitorCanAssassin = new CustomToggleOption(num++, MultiMenu.imposter, "option.imposter.TraitorCanAssassin", false);
        AssassinKills = new CustomNumberOption(num++, MultiMenu.imposter, "option.imposter.AssassinKills", 1, 1, 15, 1);
        AssassinMultiKill = new CustomToggleOption(num++, MultiMenu.imposter, "option.imposter.AssassinMultiKill", false);
        AssassinCrewmateGuess = new CustomToggleOption(num++, MultiMenu.imposter, "option.imposter.AssassinCrewmateGuess", false);
        AssassinGuessNeutralBenign = new CustomToggleOption(num++, MultiMenu.imposter, "option.imposter.AssassinGuessNeutralBenign", false);
        AssassinGuessNeutralEvil = new CustomToggleOption(num++, MultiMenu.imposter, "option.imposter.AssassinGuessNeutralEvil", false);
        AssassinGuessNeutralKilling = new CustomToggleOption(num++, MultiMenu.imposter, "option.imposter.AssassinGuessNeutralKilling", false);
        AssassinGuessImpostors = new CustomToggleOption(num++, MultiMenu.imposter, "option.imposter.AssassinGuessImpostors", false);
        AssassinGuessModifiers = new CustomToggleOption(num++, MultiMenu.imposter, "option.imposter.AssassinGuessModifiers", false);
        AssassinGuessLovers = new CustomToggleOption(num++, MultiMenu.imposter, "option.imposter.AssassinGuessLovers", false);
        AssassinateAfterVoting = new CustomToggleOption(num++, MultiMenu.imposter, "option.imposter.AssassinateAfterVoting", false);
    }
}