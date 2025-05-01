using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmongUs.GameOptions;
using HarmonyLib;
using Reactor.Utilities.Extensions;
using TMPro;
using TownOfWeekend.Extensions;
using TownOfWeekend.Patches.ScreenEffects;
using TownOfWeekend.Roles;
using UnityEngine;

namespace TownOfWeekend.Patches;

internal static class AdditionalTempData
{
    public static List<PlayerRoleInfo> playerRoles = new();
    public static List<Winners> otherWinners = new();

    public static void clear()
    {
        playerRoles.Clear();
        otherWinners.Clear();
    }

    internal class PlayerRoleInfo
    {
        public string PlayerName { get; set; }
        public string Role { get; set; }
    }

    internal class Winners
    {
        public string PlayerName { get; set; }
        public RoleEnum Role { get; set; }
    }
}

[HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnGameEnd))]
public class OnGameEndPatch
{
    public static void Postfix(AmongUsClient __instance, [HarmonyArgument(0)] EndGameResult endGameResult)
    {
        if (CameraEffect.singleton) CameraEffect.singleton.materials.Clear();
        AdditionalTempData.clear();
        var playerRole = "";
        // Theres a better way of doing this e.g. switch statement or dictionary. But this works for now.
        foreach (var playerControl in PlayerControl.AllPlayerControls)
        {
            playerRole = "";
            foreach (var role in Role.RoleHistory.Where(x => x.Key == playerControl.PlayerId))
            {
                if (role.Value == RoleEnum.Crewmate)
                    playerRole += "<color=#" + Colors.Crewmate.ToHtmlStringRGBA() + ">Crewmate</color> > ";
                else if (role.Value == RoleEnum.Impostor)
                    playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Impostor</color> > ";
                else if (role.Value == RoleEnum.Altruist)
                    playerRole += "<color=#" + Colors.Altruist.ToHtmlStringRGBA() + ">Altruist</color> > ";
                else if (role.Value == RoleEnum.Engineer)
                    playerRole += "<color=#" + Colors.Engineer.ToHtmlStringRGBA() + ">Engineer</color> > ";
                else if (role.Value == RoleEnum.Investigator)
                    playerRole += "<color=#" + Colors.Investigator.ToHtmlStringRGBA() + ">Investigator</color> > ";
                else if (role.Value == RoleEnum.Mayor)
                    playerRole += "<color=#" + Colors.Mayor.ToHtmlStringRGBA() + ">Mayor</color> > ";
                else if (role.Value == RoleEnum.Medic)
                    playerRole += "<color=#" + Colors.Medic.ToHtmlStringRGBA() + ">Medic</color> > ";
                else if (role.Value == RoleEnum.Sheriff)
                    playerRole += "<color=#" + Colors.Sheriff.ToHtmlStringRGBA() + ">Sheriff</color> > ";
                else if (role.Value == RoleEnum.Swapper)
                    playerRole += "<color=#" + Colors.Swapper.ToHtmlStringRGBA() + ">Swapper</color> > ";
                else if (role.Value == RoleEnum.Seer || role.Value == RoleEnum.CultistSeer)
                    playerRole += "<color=#" + Colors.Seer.ToHtmlStringRGBA() + ">Seer</color> > ";
                else if (role.Value == RoleEnum.Snitch || role.Value == RoleEnum.CultistSnitch)
                    playerRole += "<color=#" + Colors.Snitch.ToHtmlStringRGBA() + ">Snitch</color> > ";
                else if (role.Value == RoleEnum.Spy)
                    playerRole += "<color=#" + Colors.Spy.ToHtmlStringRGBA() + ">Spy</color> > ";
                else if (role.Value == RoleEnum.Vigilante)
                    playerRole += "<color=#" + Colors.Vigilante.ToHtmlStringRGBA() + ">Vigilante</color> > ";
                else if (role.Value == RoleEnum.Arsonist)
                    playerRole += "<color=#" + Colors.Arsonist.ToHtmlStringRGBA() + ">Arsonist</color> > ";
                else if (role.Value == RoleEnum.Executioner)
                    playerRole += "<color=#" + Colors.Executioner.ToHtmlStringRGBA() + ">Executioner</color> > ";
                else if (role.Value == RoleEnum.Glitch)
                    playerRole += "<color=#" + Colors.Glitch.ToHtmlStringRGBA() + ">The Glitch</color> > ";
                else if (role.Value == RoleEnum.Jester)
                    playerRole += "<color=#" + Colors.Jester.ToHtmlStringRGBA() + ">Jester</color> > ";
                else if (role.Value == RoleEnum.Phantom)
                    playerRole += "<color=#" + Colors.Phantom.ToHtmlStringRGBA() + ">Phantom</color> > ";
                else if (role.Value == RoleEnum.Grenadier)
                    playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Grenadier</color> > ";
                else if (role.Value == RoleEnum.Janitor)
                    playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Janitor</color> > ";
                else if (role.Value == RoleEnum.Miner)
                    playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Miner</color> > ";
                else if (role.Value == RoleEnum.Morphling)
                    playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Morphling</color> > ";
                else if (role.Value == RoleEnum.Swooper)
                    playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Swooper</color> > ";
                else if (role.Value == RoleEnum.Undertaker)
                    playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Undertaker</color> > ";
                else if (role.Value == RoleEnum.Haunter)
                    playerRole += "<color=#" + Colors.Haunter.ToHtmlStringRGBA() + ">Haunter</color> > ";
                else if (role.Value == RoleEnum.Veteran)
                    playerRole += "<color=#" + Colors.Veteran.ToHtmlStringRGBA() + ">Veteran</color> > ";
                else if (role.Value == RoleEnum.Amnesiac)
                    playerRole += "<color=#" + Colors.Amnesiac.ToHtmlStringRGBA() + ">Amnesiac</color> > ";
                else if (role.Value == RoleEnum.Juggernaut)
                    playerRole += "<color=#" + Colors.Juggernaut.ToHtmlStringRGBA() + ">Juggernaut</color> > ";
                else if (role.Value == RoleEnum.Tracker)
                    playerRole += "<color=#" + Colors.Tracker.ToHtmlStringRGBA() + ">Tracker</color> > ";
                else if (role.Value == RoleEnum.Transporter)
                    playerRole += "<color=#" + Colors.Transporter.ToHtmlStringRGBA() + ">Transporter</color> > ";
                else if (role.Value == RoleEnum.Traitor)
                    playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Traitor</color> > ";
                else if (role.Value == RoleEnum.Medium)
                    playerRole += "<color=#" + Colors.Medium.ToHtmlStringRGBA() + ">Medium</color> > ";
                else if (role.Value == RoleEnum.Trapper)
                    playerRole += "<color=#" + Colors.Trapper.ToHtmlStringRGBA() + ">Trapper</color> > ";
                else if (role.Value == RoleEnum.Survivor)
                    playerRole += "<color=#" + Colors.Survivor.ToHtmlStringRGBA() + ">Survivor</color> > ";
                else if (role.Value == RoleEnum.GuardianAngel)
                    playerRole += "<color=#" + Colors.GuardianAngel.ToHtmlStringRGBA() + ">Guardian Angel</color> > ";
                else if (role.Value == RoleEnum.Mystic || role.Value == RoleEnum.CultistMystic)
                    playerRole += "<color=#" + Colors.Mystic.ToHtmlStringRGBA() + ">Mystic</color> > ";
                else if (role.Value == RoleEnum.Blackmailer)
                    playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Blackmailer</color> > ";
                else if (role.Value == RoleEnum.Plaguebearer)
                    playerRole += "<color=#" + Colors.Plaguebearer.ToHtmlStringRGBA() + ">Plaguebearer</color> > ";
                else if (role.Value == RoleEnum.Pestilence)
                    playerRole += "<color=#" + Colors.Pestilence.ToHtmlStringRGBA() + ">Pestilence</color> > ";
                else if (role.Value == RoleEnum.Werewolf)
                    playerRole += "<color=#" + Colors.Werewolf.ToHtmlStringRGBA() + ">Werewolf</color> > ";
                else if (role.Value == RoleEnum.Detective)
                    playerRole += "<color=#" + Colors.Detective.ToHtmlStringRGBA() + ">Detective</color> > ";
                else if (role.Value == RoleEnum.Escapist)
                    playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Escapist</color> > ";
                else if (role.Value == RoleEnum.Necromancer)
                    playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Necromancer</color> > ";
                else if (role.Value == RoleEnum.Whisperer)
                    playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Whisperer</color> > ";
                else if (role.Value == RoleEnum.Chameleon)
                    playerRole += "<color=#" + Colors.Chameleon.ToHtmlStringRGBA() + ">Chameleon</color> > ";
                else if (role.Value == RoleEnum.Imitator)
                    playerRole += "<color=#" + Colors.Imitator.ToHtmlStringRGBA() + ">Imitator</color> > ";
                else if (role.Value == RoleEnum.Bomber)
                    playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Bomber</color> > ";
                else if (role.Value == RoleEnum.Doomsayer)
                    playerRole += "<color=#" + Colors.Doomsayer.ToHtmlStringRGBA() + ">Doomsayer</color> > ";
                else if (role.Value == RoleEnum.Vampire)
                    playerRole += "<color=#" + Colors.Vampire.ToHtmlStringRGBA() + ">Vampire</color> > ";
                else if (role.Value == RoleEnum.VampireHunter)
                    playerRole += "<color=#" + Colors.VampireHunter.ToHtmlStringRGBA() + ">Vampire Hunter</color> > ";
                else if (role.Value == RoleEnum.Prosecutor)
                    playerRole += "<color=#" + Colors.Prosecutor.ToHtmlStringRGBA() + ">Prosecutor</color> > ";
                else if (role.Value == RoleEnum.Warlock)
                    playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Warlock</color> > ";
                else if (role.Value == RoleEnum.Oracle)
                    playerRole += "<color=#" + Colors.Oracle.ToHtmlStringRGBA() + ">Oracle</color> > ";
                else if (role.Value == RoleEnum.Venerer)
                    playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Venerer</color> > ";
                else if (role.Value == RoleEnum.Aurial)
                    playerRole += "<color=#" + Colors.Aurial.ToHtmlStringRGBA() + ">Aurial</color> > ";
                if (CustomGameOptions.GameMode == GameMode.Cultist && playerControl.Data.IsImpostor())
                {
                    if (role.Value == RoleEnum.Engineer)
                        playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Demolitionist</color> > ";
                    else if (role.Value == RoleEnum.Investigator)
                        playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Consigliere</color> > ";
                    else if (role.Value == RoleEnum.CultistMystic)
                        playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Clairvoyant</color> > ";
                    else if (role.Value == RoleEnum.CultistSnitch)
                        playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Informant</color> > ";
                    else if (role.Value == RoleEnum.Spy)
                        playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Rogue Agent</color> > ";
                    else if (role.Value == RoleEnum.Vigilante)
                        playerRole += "<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Assassin</color> > ";
                }
            }

            playerRole = playerRole.Remove(playerRole.Length - 3);

            if (playerControl.Is(ModifierEnum.Giant))
                playerRole += " (<color=#" + Colors.Giant.ToHtmlStringRGBA() + ">Giant</color>)";
            else if (playerControl.Is(ModifierEnum.ButtonBarry))
                playerRole += " (<color=#" + Colors.ButtonBarry.ToHtmlStringRGBA() + ">Button Barry</color>)";
            else if (playerControl.Is(ModifierEnum.Aftermath))
                playerRole += " (<color=#" + Colors.Aftermath.ToHtmlStringRGBA() + ">Aftermath</color>)";
            else if (playerControl.Is(ModifierEnum.Bait))
                playerRole += " (<color=#" + Colors.Bait.ToHtmlStringRGBA() + ">Bait</color>)";
            else if (playerControl.Is(ModifierEnum.Diseased))
                playerRole += " (<color=#" + Colors.Diseased.ToHtmlStringRGBA() + ">Diseased</color>)";
            else if (playerControl.Is(ModifierEnum.Flash))
                playerRole += " (<color=#" + Colors.Flash.ToHtmlStringRGBA() + ">Flash</color>)";
            else if (playerControl.Is(ModifierEnum.Tiebreaker))
                playerRole += " (<color=#" + Colors.Tiebreaker.ToHtmlStringRGBA() + ">Tiebreaker</color>)";
            else if (playerControl.Is(ModifierEnum.Torch))
                playerRole += " (<color=#" + Colors.Torch.ToHtmlStringRGBA() + ">Torch</color>)";
            else if (playerControl.Is(ModifierEnum.Lover))
                playerRole += " (<color=#" + Colors.Lovers.ToHtmlStringRGBA() + ">Lover</color>)";
            else if (playerControl.Is(ModifierEnum.Sleuth))
                playerRole += " (<color=#" + Colors.Sleuth.ToHtmlStringRGBA() + ">Sleuth</color>)";
            else if (playerControl.Is(ModifierEnum.Radar))
                playerRole += " (<color=#" + Colors.Radar.ToHtmlStringRGBA() + ">Radar</color>)";
            else if (playerControl.Is(ModifierEnum.Disperser))
                playerRole += " (<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Disperser</color>)";
            else if (playerControl.Is(ModifierEnum.Multitasker))
                playerRole += " (<color=#" + Colors.Multitasker.ToHtmlStringRGBA() + ">Multitasker</color>)";
            else if (playerControl.Is(ModifierEnum.DoubleShot))
                playerRole += " (<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Double Shot</color>)";
            else if (playerControl.Is(ModifierEnum.Underdog))
                playerRole += " (<color=#" + Colors.Impostor.ToHtmlStringRGBA() + ">Underdog</color>)";
            else if (playerControl.Is(ModifierEnum.Frosty))
                playerRole += " (<color=#" + Colors.Frosty.ToHtmlStringRGBA() + ">Frosty</color>)";
            var player = Role.GetRole(playerControl);
            if (playerControl.Is(RoleEnum.Phantom) || playerControl.Is(Faction.Crewmates))
            {
                if ((player.TotalTasks - player.TasksLeft) / player.TotalTasks == 1)
                    playerRole += " | Tasks: <color=#" + Color.green.ToHtmlStringRGBA() +
                                  $">{player.TotalTasks - player.TasksLeft}/{player.TotalTasks}</color>";
                else playerRole += $" | Tasks: {player.TotalTasks - player.TasksLeft}/{player.TotalTasks}";
            }

            if (player.Kills > 0 && !playerControl.Is(Faction.Crewmates))
                playerRole += " |<color=#" + Colors.Impostor.ToHtmlStringRGBA() + $"> Kills: {player.Kills}</color>";
            if (player.CorrectKills > 0)
                playerRole += " |<color=#" + Color.green.ToHtmlStringRGBA() +
                              $"> Correct Kills: {player.CorrectKills}</color>";
            if (player.IncorrectKills > 0)
                playerRole += " |<color=#" + Colors.Impostor.ToHtmlStringRGBA() +
                              $"> Incorrect Kills: {player.IncorrectKills}</color>";
            if (player.CorrectAssassinKills > 0)
                playerRole += " |<color=#" + Color.green.ToHtmlStringRGBA() +
                              $"> Correct Guesses: {player.CorrectAssassinKills}</color>";
            if (player.IncorrectAssassinKills > 0)
                playerRole += " |<color=#" + Colors.Impostor.ToHtmlStringRGBA() +
                              $"> Incorrect Guesses: {player.IncorrectAssassinKills}</color>";
            AdditionalTempData.playerRoles.Add(new AdditionalTempData.PlayerRoleInfo
                { PlayerName = playerControl.Data.PlayerName, Role = playerRole });
        }

        if (!CustomGameOptions.NeutralEvilWinEndsGame)
        {
            foreach (var doomsayer in Role.GetRoles(RoleEnum.Doomsayer))
            {
                var doom = (Doomsayer)doomsayer;
                if (doom.WonByGuessing)
                    AdditionalTempData.otherWinners.Add(new AdditionalTempData.Winners
                        { PlayerName = doom.Player.Data.PlayerName, Role = RoleEnum.Doomsayer });
            }

            foreach (var executioner in Role.GetRoles(RoleEnum.Executioner))
            {
                var exe = (Executioner)executioner;
                if (exe.TargetVotedOut)
                    AdditionalTempData.otherWinners.Add(new AdditionalTempData.Winners
                        { PlayerName = exe.Player.Data.PlayerName, Role = RoleEnum.Executioner });
            }

            foreach (var jester in Role.GetRoles(RoleEnum.Jester))
            {
                var jest = (Jester)jester;
                if (jest.VotedOut)
                    AdditionalTempData.otherWinners.Add(new AdditionalTempData.Winners
                        { PlayerName = jest.Player.Data.PlayerName, Role = RoleEnum.Jester });
            }

            foreach (var phantom in Role.GetRoles(RoleEnum.Phantom))
            {
                var phan = (Phantom)phantom;
                if (phan.CompletedTasks)
                    AdditionalTempData.otherWinners.Add(new AdditionalTempData.Winners
                        { PlayerName = phan.Player.Data.PlayerName, Role = RoleEnum.Phantom });
            }
        }
    }
}

[HarmonyPatch(typeof(EndGameManager), nameof(EndGameManager.SetEverythingUp))]
public class EndGameManagerSetUpPatch
{
    public static void Postfix(EndGameManager __instance)
    {
        if (GameOptionsManager.Instance.CurrentGameOptions.GameMode == GameModes.HideNSeek) return;

        var bonusText = Object.Instantiate(__instance.WinText.gameObject);
        bonusText.transform.position = new Vector3(__instance.WinText.transform.position.x,
            __instance.WinText.transform.position.y - 0.8f, __instance.WinText.transform.position.z);
        bonusText.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
        var textRenderer = bonusText.GetComponent<TMP_Text>();
        textRenderer.text = "";

        var position = Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, Camera.main.nearClipPlane));
        var roleSummary = Object.Instantiate(__instance.WinText.gameObject);
        roleSummary.transform.position = new Vector3(__instance.Navigation.ExitButton.transform.position.x + 0.1f,
            position.y - 0.1f, -14f);
        roleSummary.transform.localScale = new Vector3(1f, 1f, 1f);

        var roleSummaryText = new StringBuilder();
        roleSummaryText.AppendLine("End game summary:");
        foreach (var data in AdditionalTempData.playerRoles)
        {
            var role = string.Join(" ", data.Role);
            roleSummaryText.AppendLine($"{data.PlayerName} - {role}");
        }

        if (AdditionalTempData.otherWinners.Count != 0)
        {
            roleSummaryText.AppendLine("\n\n\nOther Winners:");
            foreach (var data in AdditionalTempData.otherWinners)
                if (data.Role == RoleEnum.Doomsayer)
                    roleSummaryText.AppendLine("<color=#" + Colors.Doomsayer.ToHtmlStringRGBA() +
                                               $">{data.PlayerName}</color>");
                else if (data.Role == RoleEnum.Executioner)
                    roleSummaryText.AppendLine("<color=#" + Colors.Executioner.ToHtmlStringRGBA() +
                                               $">{data.PlayerName}</color>");
                else if (data.Role == RoleEnum.Jester)
                    roleSummaryText.AppendLine("<color=#" + Colors.Jester.ToHtmlStringRGBA() +
                                               $">{data.PlayerName}</color>");
                else if (data.Role == RoleEnum.Phantom)
                    roleSummaryText.AppendLine("<color=#" + Colors.Phantom.ToHtmlStringRGBA() +
                                               $">{data.PlayerName}</color>");
        }

        var roleSummaryTextMesh = roleSummary.GetComponent<TMP_Text>();
        roleSummaryTextMesh.alignment = TextAlignmentOptions.TopLeft;
        roleSummaryTextMesh.color = Color.white;
        roleSummaryTextMesh.fontSizeMin = 1.5f;
        roleSummaryTextMesh.fontSizeMax = 1.5f;
        roleSummaryTextMesh.fontSize = 1.5f;

        var roleSummaryTextMeshRectTransform = roleSummaryTextMesh.GetComponent<RectTransform>();
        roleSummaryTextMeshRectTransform.anchoredPosition = new Vector2(position.x + 3.5f, position.y - 0.1f);
        roleSummaryTextMesh.text = roleSummaryText.ToString();

        AdditionalTempData.clear();
    }
}