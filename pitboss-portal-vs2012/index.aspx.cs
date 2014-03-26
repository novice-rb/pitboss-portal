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

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ShowGameInfo();
            int turn = ShowTimeInfo();
            var events = ShowEvents();
            ShowPlayerSummary(turn, events);
        }

        private void ShowGameInfo()
        {
            var gameName = GetSetting("GameName", "Pitboss Game");
            this.Page.Header.Title = "Pitboss Portal - " + gameName;
            litGameName.Text = gameName;
            litConnectionAddress.Text = GetSetting("ConnectionAddress", "");
            string modUrl = GetSetting("VersionLink", "");
            string mod = GetSetting("Version", "Beyond the Sword");
            if (!string.IsNullOrEmpty(modUrl)) mod = "<a href=\"" + modUrl + "\">" + mod + "</a>";
            litGameVersion.Text = mod;
            litExternalLinks.Text = "";
            int linkId = 1;
            string link = GetSetting("ExternalLink" + linkId, null);
            while (!string.IsNullOrEmpty(link))
            {
                string[] linkParts = link.Split('|');
                litExternalLinks.Text += "<div class=\"externalLink\"><a href=\"" + linkParts[0] + "\">" + (linkParts.Length > 1 ? linkParts[1] : linkParts[0]) + "</a></div>";
                linkId++;
                link = GetSetting("ExternalLink" + linkId, null);
            }
        }

        private List<EventLine> ShowEvents()
        {
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
            int utcOffset = int.Parse(GetSetting("SystemTimeUTCOffset", "1"));
            foreach (string line in eventInfo)
            {
                EventLine evt = new EventLine(line, _selectedTimeZone, utcOffset);
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
                    if (evt.Turn > currentTurn) newEvents.Add(new EventLine(evt.EventTime, evt.EventTimeParsed, "", "turnroll", "A new turn has begun. It is now turn " + evt.Turn + ".", -1, evt.Turn));
                    if (evt.Turn < currentTurn) newEvents.Add(new EventLine(evt.EventTime, evt.EventTimeParsed, "", "reload", "A reload has been detected. It is now turn " + evt.Turn + ".", -1, evt.Turn));
                }
                currentTurn = evt.Turn;
                if (PlayerNames.ContainsKey(evt.PlayerId))
                {
                    if (PlayerNames[evt.PlayerId] != evt.PlayerName)
                    {
                        newEvents.Add(new EventLine(evt.EventTime, evt.EventTimeParsed, evt.PlayerName, "namechange", PlayerNames[evt.PlayerId] + " changed name to " + evt.PlayerName, evt.PlayerId, evt.Turn));
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
            return newEvents;
        }

        private TimeZoneInfo _selectedTimeZone = null;
        private int ShowTimeInfo()
        {
            int turn = -1;
            List<string> timeInfo = new List<string>();
            try
            {
                timeInfo = FileReader.ReadFile(GetSettingPath("TimeFile", "testdata/time.txt"), 0);
            }
            catch (Exception ex)
            {
                litTimeLeft.Text = "Error reading time.txt: " + ex.Message;
            }
            if (timeInfo.Count > 0) litTimeLeft.Text = timeInfo[0];
            if (timeInfo.Count > 1)
            {
                litSystemTime.Text = timeInfo[1]; //"Sun Mar 16 19:24:41 2014"
                if (timeInfo.Count > 3)
                {
                    string year = timeInfo[2];
                    turn = int.Parse(timeInfo[3]);
                    bool bc = year.StartsWith("-");
                    year = year.Replace("-", "").Replace("+", "");
                    litYear.Text = "It is turn " + turn + " (" + year + " " + (bc ? "BC" : "AD") + ")";
                }
                try
                {
                    string[] timeLeftParts = timeInfo[0].Split(':');
                    TimeSpan timeLeft = new TimeSpan(int.Parse(timeLeftParts[0]), int.Parse(timeLeftParts[1]), int.Parse(timeLeftParts[2]));
                    //TimeSpan timeLeft = TimeSpan.ParseExact(timeInfo[0], "HH:mm:ss", CultureInfo.InvariantCulture);
                    DateTime now = DateTime.ParseExact(timeInfo[1].Substring(4), "MMM dd HH:mm:ss yyyy", CultureInfo.InvariantCulture);
                    int utcOffset = int.Parse(GetSetting("SystemTimeUTCOffset", "1"));
                    litSystemTimeUTCOffset.Text = utcOffset == 0 ? "" : ((utcOffset > 0 ? "+" : "-") + utcOffset);
                    now = now.AddHours(0-utcOffset);
                    DateTime turnRoll = now.Add(timeLeft);
                    //litTurnRoll.Text = "<div class=\"timeZone timeZoneSystemTime\">System time: " + turnRoll.ToString("ddd MMM dd HH:mm:ss yyyy", CultureInfo.InvariantCulture) + "</div>\n";
                    if (!Page.IsPostBack)
                    {
                        ddlTimeZone.Items.Clear();
                        foreach (var timeZone in TimeZoneInfo.GetSystemTimeZones())
                        {
                            string timeZoneId = GetTimeZoneId(timeZone);
                            ddlTimeZone.Items.Add(new ListItem(timeZone.DisplayName, timeZoneId));
                        }
                        var cookie = Page.Request.Cookies.Get("selectedTimeZone");
                        if(cookie != null) ddlTimeZone.SelectedValue = cookie.Value;
                    }
                    if (ddlTimeZone.SelectedIndex > -1)
                    {
                        string selectedTimeZoneId = ddlTimeZone.SelectedValue;
                        foreach (var timeZone in TimeZoneInfo.GetSystemTimeZones())
                        {
                            string timeZoneId = GetTimeZoneId(timeZone);
                            if (timeZoneId == selectedTimeZoneId) _selectedTimeZone = timeZone;
                        }
                    }
                    if (_selectedTimeZone == null) _selectedTimeZone = TimeZoneInfo.Local;
                    ddlTimeZone.SelectedValue = GetTimeZoneId(_selectedTimeZone);
                    HttpCookie timeZoneCookie = new HttpCookie("selectedTimeZone", GetTimeZoneId(_selectedTimeZone));
                    timeZoneCookie.Expires = DateTime.Now.AddYears(10);
                    Page.Response.Cookies.Add(timeZoneCookie);
                    litYourTime.Text = TimeZoneInfo.ConvertTimeFromUtc(now, _selectedTimeZone).ToString("ddd MMM dd HH:mm:ss yyyy", CultureInfo.InvariantCulture);
                    litTurnRoll.Text = TimeZoneInfo.ConvertTimeFromUtc(turnRoll, _selectedTimeZone).ToString("ddd MMM dd HH:mm:ss yyyy", CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    litTurnRoll.Text = "You do the math! (I failed with the error " + ex.Message + ")";
                }
            }
            return turn;
        }

        private static string GetTimeZoneId(TimeZoneInfo timeZone)
        {
            string timeZoneId = timeZone.Id.Replace(" ", "").Replace(".", "").Replace("+", "plus").Replace("-", "minus");
            return timeZoneId;
        }

        private void ShowPlayerSummary(int turn, List<EventLine> events)
        {
            var scoreHtml = @"
<div class=""playerHeader"">
    <div class=""playerEndedTurn"">&nbsp;</div>
    <div class=""playerName"">Last login</div>
    <div class=""teamName"">Players</div>
    <div class=""leaderName"">Leader</div>
    <div class=""civilizationName"">Civilization</div>
    <div class=""playerScore"">Score</div>
    <div class=""onlineStatus"">Status</div>
</div>";
            List<string> scoreInfo = new List<string>();
            try
            {
                scoreInfo = FileReader.ReadFile(GetSettingPath("ScoreFile", "testdata/score.txt"), 0);
            }
            catch (Exception ex)
            {
                scoreHtml = "Error reading score.txt: " + ex.Message;
            }
            List<PlayerInfo> players = new List<PlayerInfo>();
            try
            {
                Dictionary<int, PlayerInfo> playersByPlayerId = new Dictionary<int, PlayerInfo>();
                List<string> playerStrings = FileReader.ReadFile(GetSettingPath("PlayersFile", "testdata/players.txt"), 0);
                foreach (string p in playerStrings)
                {
                    PlayerInfo pl = new PlayerInfo(p);
                    playersByPlayerId[pl.PlayerId] = pl;
                    players.Add(pl);
                }
                foreach (string line in scoreInfo)
                {
                    try
                    {
                        string[] parts = line.Split(new string[] { "---" }, StringSplitOptions.None);
                        int playerId = int.Parse(parts[3].Trim());
                        PlayerInfo pl = playersByPlayerId[playerId];
                        pl.Score = int.Parse(parts[2].Trim());
                        pl.PlayerName = parts[1].Trim();
                        pl.HasEndedTurn = (parts[0].Trim() == "*");
                    }
                    catch (Exception ex2)
                    {
                        scoreHtml += "<div class=\"player\">Error processing score line &quot;" + line + "&quot;: " + ex2.Message + "</div>";
                    }
                }
            }
            catch (Exception ex)
            {
                scoreHtml = "Error parsing score.txt or players.txt: " + ex.Message;
            }
            
            if (turn < 0) turn = events.Max(e => e.Turn);
            var turnEvents = events.Where(e => e.Turn == turn).Reverse();
            foreach (var pl in players)
            {
                foreach (var evt in turnEvents.Where(evt => evt.PlayerId == pl.PlayerId))
                {
                    if (evt.EventType == "endturn")
                    {
                        pl.HasLoggedIn = true;
                    }
                    else if (evt.EventType == "connected")
                    {
                        pl.HasLoggedIn = true;
                        pl.IsLoggedIn = true;
                    }
                    else if (evt.EventType == "disconnected")
                    {
                        pl.HasLoggedIn = true;
                        pl.IsLoggedIn = false;
                    }
                }
                scoreHtml += pl.ToHtml();
            }
            litPlayerSummary.Text = scoreHtml;

            int playerCount = players.Count;
            litNumberDone.Text = players.Count(p => p.HasEndedTurn) + " of " + playerCount;
            litNumberLoggedIn.Text = players.Count(p => p.HasLoggedIn && !p.HasEndedTurn) + " of " + playerCount;
            litNumberLeft.Text = players.Count(p => !p.HasLoggedIn && !p.HasEndedTurn) + " of " + playerCount;
        }

        protected void ddlTimeZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(ddlTimeZone.SelectedValue);
        }
    }
}