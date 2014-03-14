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

            var timeInfo = Parser.ReadFile(Parser.GetSetting("TimeFile", "testdata/time.txt"));
            litTimeLeft.Text = "Time left: " + timeInfo[0];
            litTurnRoll.Text = "Turn rolls " + timeInfo[1];

            var scoreHtml = "";
            var scoreInfo = Parser.ReadFile(Parser.GetSetting("ScoreFile", "testdata/score.txt"));
            foreach (string line in scoreInfo)
            {
                string[] parts = line.Split(new string[] {"---"}, StringSplitOptions.None);
                scoreHtml += "<div class=\"player\">\n";
                scoreHtml += "<div class=\"playerName\">" + parts[0].Trim() + "</div>\n";
                scoreHtml += "<div class=\"playerScore\">" + parts[1].Trim() + "</div>\n";
                scoreHtml += "</div>\n";
            }
            litPlayerSummary.Text = scoreHtml;
        }
    }
}