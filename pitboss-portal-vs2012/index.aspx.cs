using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pitboss_portal
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            litTitle.Text = Parser.GetSetting("GameName", "Pitboss Game");
            litGameName.Text = litTitle.Text;

            var timeInfo = Parser.ReadFile(Parser.GetSetting("TimeFile", "testdata/time.txt"), 0);
            litTimeLeft.Text = "Time left: " + timeInfo[0];
            litTurnRoll.Text = "Turn rolls " + timeInfo[1];

            var scoreHtml = "";
            var scoreInfo = Parser.ReadFile(Parser.GetSetting("ScoreFile", "testdata/score.txt"), 0);
            scoreHtml += "<div class=\"playerHeader\">\n";
            scoreHtml += "<div class=\"playerEndedTurn\">Ended turn?</div>\n";
            scoreHtml += "<div class=\"playerName\">Player</div>\n";
            scoreHtml += "<div class=\"playerScore\">Score</div>\n";
            scoreHtml += "</div>\n";
            foreach (string line in scoreInfo)
            {
                string[] parts = line.Split(new string[] {"---"}, StringSplitOptions.None);
                scoreHtml += "<div class=\"player\">\n";
                scoreHtml += "<div class=\"playerEndedTurn\">" + parts[0].Trim() + "</div>\n";
                scoreHtml += "<div class=\"playerName\">" + parts[1].Trim() + "</div>\n";
                scoreHtml += "<div class=\"playerScore\">" + parts[2].Trim() + "</div>\n";
                scoreHtml += "</div>\n";
            }
            litPlayerSummary.Text = scoreHtml;

            var eventHtml = "";
            var eventInfo = Parser.ReadFile(Parser.GetSetting("EventFile", "testdata/event.txt"), int.Parse(Parser.GetSetting("EventCutoff", "100")));
            foreach (string line in scoreInfo)
            {
                string[] parts = line.Split(new string[] { "---" }, StringSplitOptions.None);
                eventHtml += "<div class=\"event\">\n";
                eventHtml += "<div class=\"eventTime\">" + parts[0].Trim() + "</div>\n";
                eventHtml += "<div class=\"eventPlayer\">" + parts[1].Trim() + "</div>\n";
                string eventType = parts[2].Trim();
                int score = 0;
                if (int.TryParse(eventType, out score)) eventType = "Score changed to " + score;
                eventHtml += "<div class=\"eventType\">" + eventType + "</div>\n";
                eventHtml += "</div>\n";
            }
            litEventLog.Text = eventHtml;
        }
    }
}