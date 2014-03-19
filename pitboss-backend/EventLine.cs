﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pitboss_backend
{
    public class EventLine
    {
        public EventLine(string eventTime, string playerName, string eventType, string eventTypeDescription, int playerId, int turn)
        {
            this.EventTime = eventTime;
            this.PlayerName = playerName;
            this.EventType = eventType;
            this.EventTypeDescription = eventTypeDescription;
            this.PlayerId = playerId;
            this.Turn = turn;
        }

        public EventLine(string line)
        {
            this.RawLine = line;
            try
            {
                string[] parts = line.Split(new string[] { "---" }, StringSplitOptions.None);
                this.EventTime = parts[0].Trim();
                this.PlayerName = parts[1].Trim();
                this.EventType = parts[2].Trim();
                int score = 0;
                if (int.TryParse(this.EventType, out score))
                {
                    this.EventTypeDescription = "Score changed to " + score;
                    this.EventType = "scorechange";
                }
                else
                {
                    this.EventTypeDescription = this.EventType;
                    this.EventType = this.EventType.Replace(" ", "").ToLower();
                }
                this.PlayerId = int.Parse(parts[3].Trim());
                this.Turn = int.Parse(parts[4].Trim());
            }
            catch (Exception ex)
            {
                this.ParseException = ex;
            }
        }

        public string ToHtml()
        {
            if (ParseException != null) return "<div class=\"event\">Error parsing event line &quot;" + RawLine + "&quot;: " + ParseException.Message + "</div>";
            string eventHtml = "<div class=\"event eventType" + EventType + "\">\n";
            eventHtml += "<div class=\"eventTime\">" + EventTime + "</div>\n";
            eventHtml += "<div class=\"eventPlayer\">" + PlayerName + "</div>\n";
            eventHtml += "<div class=\"eventTurn\">Turn " + Turn + "</div>\n";
            eventHtml += "<div class=\"eventType\">" + EventTypeDescription + "</div>\n";
            eventHtml += "</div>\n";
            return eventHtml;
        }

        public string RawLine { get; private set; }
        public string EventTime { get; private set; }
        public string PlayerName { get; private set; }
        public string EventType { get; private set; }
        public string EventTypeDescription { get; private set; }
        public int PlayerId { get; private set; }
        public int Turn { get; private set; }
        public Exception ParseException { get; private set; }
    }

}