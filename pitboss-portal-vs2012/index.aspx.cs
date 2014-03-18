using pitboss_backend;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pitboss_portal
{
    public partial class index : System.Web.UI.Page
    {
        private string GetSetting(string key, string defaultValue)
        {
            string value = System.Web.Configuration.WebConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(value)) return defaultValue;
            return value;
        }

        private string GetSettingPath(string key, string defaultValue)
        {
            string filepath = GetSetting(key, defaultValue);
            if (!System.IO.Path.IsPathRooted(filepath))
            {
                filepath = HttpContext.Current.Server.MapPath(filepath);
            }
            return filepath;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            litTitle.Text = GetSetting("GameName", "Pitboss Game");
            litGameName.Text = litTitle.Text;

            List<string> timeInfo = new List<string>();
            try
            {
                timeInfo = FileReader.ReadFile(GetSettingPath("TimeFile", "testdata/time.txt"), 0);
            }
            catch (Exception ex)
            {
                litTimeLeft.Text = "Error reading time.txt: " + ex.Message;
            }
            if(timeInfo.Count > 0) litTimeLeft.Text = timeInfo[0];
            if (timeInfo.Count > 1)
            {
                litSystemTime.Text = timeInfo[1]; //"Sun Mar 16 19:24:41 2014"
                if (timeInfo.Count > 3)
                {
                    string year = timeInfo[2];
                    string turn = timeInfo[3];
                    bool bc = year.StartsWith("-");
                    year = year.Replace("-", "").Replace("+", "");
                    litYear.Text = "It is turn " + turn + " (" + year + " " + (bc ? "BC" : "AD") + ")";
                }
                try
                {
                    string[] timeLeftParts = timeInfo[0].Split(':');
                    TimeSpan timeLeft = new TimeSpan(int.Parse(timeLeftParts[0]), int.Parse(timeLeftParts[1]), int.Parse(timeLeftParts[2]));
                    //TimeSpan timeLeft = TimeSpan.ParseExact(timeInfo[0], "HH:mm:ss", CultureInfo.InvariantCulture);
                    DateTime turnRoll = DateTime.ParseExact(timeInfo[1].Substring(4), "MMM dd HH:mm:ss yyyy", CultureInfo.InvariantCulture);
                    turnRoll = turnRoll.Add(timeLeft);
                    //litTurnRoll.Text = "<div class=\"timeZone timeZoneSystemTime\">System time: " + turnRoll.ToString("ddd MMM dd HH:mm:ss yyyy", CultureInfo.InvariantCulture) + "</div>\n";
                    foreach(var timeZone in TimeZoneInfo.GetSystemTimeZones()) {
                        litTurnRoll.Text += "<div class=\"timeZone timeZone" + timeZone.Id.Replace(" ", "").Replace(".","").Replace("+","plus") + "\"><div class=\"timeZoneName\">" + timeZone.DisplayName + ":</div><div class=\"timeZoneTime\">" + TimeZoneInfo.ConvertTimeFromUtc(turnRoll, timeZone).ToString("ddd MMM dd HH:mm:ss yyyy", CultureInfo.InvariantCulture) + "</div></div>\n";
                    }
                }
                catch (Exception ex)
                {
                    litTurnRoll.Text = "You do the math! (I failed with the error " + ex.Message + ")";
                }
            }

            var scoreHtml = "";
            scoreHtml += "<div class=\"playerHeader\">\n";
            scoreHtml += "<div class=\"playerEndedTurn\">Ended turn?</div>\n";
            scoreHtml += "<div class=\"playerName\">Player</div>\n";
            scoreHtml += "<div class=\"playerScore\">Score</div>\n";
            scoreHtml += "</div>\n";
            List<string> scoreInfo = new List<string>();
            try
            {
                scoreInfo = FileReader.ReadFile(GetSettingPath("ScoreFile", "testdata/score.txt"), 0);
            }
            catch (Exception ex)
            {
                scoreHtml = "Error reading score.txt: " + ex.Message;
            }
            foreach (string line in scoreInfo)
            {
                string[] parts = line.Split(new string[] {"---"}, StringSplitOptions.None);
                scoreHtml += "<div class=\"player\">\n";
                scoreHtml += "<div class=\"playerEndedTurn\">&nbsp;" + parts[0].Trim() + "</div>\n";
                scoreHtml += "<div class=\"playerName\">" + parts[1].Trim() + "</div>\n";
                scoreHtml += "<div class=\"playerScore\">" + parts[2].Trim() + "</div>\n";
                scoreHtml += "</div>\n";
            }
            litPlayerSummary.Text = scoreHtml;

            List<string> eventInfo = new List<string>();
            try
            {
                eventInfo = FileReader.ReadFile(GetSettingPath("EventFile", "testdata/event.txt"), int.Parse(GetSetting("EventCutoff", "100")));
            }
            catch (Exception ex)
            {
                litEventLog.Text = "Error reading event.txt: " + ex.Message;
            }
            List<EventLine> eventLines = new List<EventLine>();
            foreach (string line in eventInfo)
            {
                EventLine evt = new EventLine(line);
                eventLines.Add(evt);
            }

            var PlayerNames = new Dictionary<int, string>();
            var newEvents = new List<EventLine>();
            eventLines.Reverse();
            int currentTurn = -1;
            foreach (var evt in eventLines)
            {
                if (currentTurn != -1)
                {
                    if (evt.Turn > currentTurn) newEvents.Add(new EventLine(evt.EventTime, "", "turnroll", "A new turn has begun. It is now turn " + evt.Turn + ".", -1, evt.Turn));
                    if (evt.Turn < currentTurn) newEvents.Add(new EventLine(evt.EventTime, "", "reload", "A reload has been detected. It is now turn " + evt.Turn + ".", -1, evt.Turn));
                }
                currentTurn = evt.Turn;
                if (PlayerNames.ContainsKey(evt.PlayerId))
                {
                    if (PlayerNames[evt.PlayerId] != evt.PlayerName)
                    {
                        newEvents.Add(new EventLine(evt.EventTime, evt.PlayerName, "namechange", PlayerNames[evt.PlayerId] + " changed name to " + evt.PlayerName, evt.PlayerId, evt.Turn));
                        PlayerNames[evt.PlayerId] = evt.PlayerName;
                    }
                }
                else
                {
                    PlayerNames[evt.PlayerId] = evt.PlayerName;
                }
                newEvents.Add(evt);
            }
            newEvents.Reverse();

            if (newEvents.Count > 0)
            {
                var eventHtml = "";
                foreach (var evt in newEvents)
                {
                    eventHtml += evt.ToHtml() + "\n";
                }
                litEventLog.Text = eventHtml;
            }
        }
    }
}