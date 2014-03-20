using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pitboss_backend
{
    public class PlayerInfo
    {
        public bool HasEndedTurn { get; set; }
        public bool HasLoggedIn { get; set; }
        public bool IsLoggedIn { get; set; }
        public string PlayerName { get; set; }
        public int Score { get; set; }

        public string TeamName { get; private set; }
        public string LeaderName { get; private set; }
        public string CivilizationName { get; private set; }
        public int PlayerId { get; private set; }

        public PlayerInfo()
        {
        }

        public PlayerInfo(string line)
        {
            string[] parts = line.Split(new string[] { "---" }, StringSplitOptions.None);
            this.HasEndedTurn = false;
            this.HasLoggedIn = false;
            this.IsLoggedIn = false;
            this.Score = 0;
            this.PlayerId = int.Parse(parts[0].Trim());
            this.TeamName = parts[1].Trim();
            this.LeaderName = parts[2].Trim();
            this.CivilizationName = parts[3].Trim();
            this.PlayerName = this.LeaderName;
        }

        public string ToHtml()
        {
            string playerHtml = "<div class=\"player" + (HasEndedTurn ? " HasEndedTurn" : "") + (HasLoggedIn ? " HasLoggedIn" : "") + (IsLoggedIn ? " IsLoggedIn" : "") +"\">\n";
            playerHtml += "<div class=\"playerEndedTurn\">" + (HasEndedTurn ? "*" : "&nbsp;") + "</div>\n";
            playerHtml += "<div class=\"playerName\">" + PlayerName + "</div>\n";
            playerHtml += "<div class=\"teamName\">" + TeamName + "</div>\n";
            playerHtml += "<div class=\"leaderName\">" + LeaderName + "</div>\n";
            playerHtml += "<div class=\"civilizationName\">" + CivilizationName + "</div>\n";
            playerHtml += "<div class=\"playerScore\">" + Score + "</div>\n";
            playerHtml += "<div class=\"onlineStatus\">" + (IsLoggedIn ? (HasEndedTurn ? "Reviewing" : "Playing") : (HasEndedTurn ? "Has played" : (HasLoggedIn ? "Has looked" : "Hasn't played"))) + "</div>\n";
            playerHtml += "</div>\n";
            return playerHtml;
        }

    }
}
