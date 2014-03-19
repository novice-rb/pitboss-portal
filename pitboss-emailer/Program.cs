using pitboss_backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pitboss_emailer
{
    class Program
    {
        private static string GetSetting(string key, string defaultValue)
        {
            string value = System.Configuration.ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(value)) return defaultValue;
            return value;
        }

        private static string GetSettingPath(string key, string defaultValue)
        {
            string filepath = GetSetting(key, defaultValue);
            if (!System.IO.Path.IsPathRooted(filepath))
            {
                string codebase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                string binPath = System.IO.Path.GetDirectoryName(codebase.Replace("file:///", ""));
                filepath = System.IO.Path.Combine(binPath, "../../", filepath);
            }
            return filepath;
        }

        private static EmailUtility _Emailer;

        static void Main(string[] args)
        {
            string lastLineProcessed = ProcessEventLog();
            if (!string.IsNullOrEmpty(lastLineProcessed))
            {
                var emailerInfo = new List<string>();
                emailerInfo.Add(lastLineProcessed);
                FileReader.WriteFile(GetSettingPath("EmailerFile", "testdata/emailer.txt"), emailerInfo);
            }
            Console.WriteLine("Done processing event log.");
            //Console.ReadLine();
        }

        private static string ProcessEventLog()
        {
            List<string> emailerInfo = new List<string>();
            try
            {
                emailerInfo = FileReader.ReadFile(GetSettingPath("EmailerFile", "testdata/emailer.txt"), 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading emailer.txt: " + ex.ToString());
                return null;
            }
            try
            {
                _Emailer = new EmailUtility(int.Parse(GetSetting("WaitTimeBetweenSends", "2000")));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error setting up smtp client: " + ex.ToString());
                return null;
            }
            string lastEventProcessed = null;
            if (emailerInfo.Count > 0) lastEventProcessed = emailerInfo[0];

            // Read event log
            List<string> eventInfo = new List<string>();
            try
            {
                eventInfo = FileReader.ReadFile(GetSettingPath("EventFile", "testdata/event.txt"), 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading event.txt: " + ex.ToString());
                return null;
            }
            // Truncate at last line processed last time this utility was run
            List<string> newEvents = new List<string>();
            foreach (string line in eventInfo)
            {
                if (!string.IsNullOrEmpty(lastEventProcessed) && line == lastEventProcessed) break;
                newEvents.Add(line);
            }
            newEvents.Reverse();

            // What was the turn number for the last event processed?
            int lastTurnProcessed = 0;
            if (!string.IsNullOrEmpty(lastEventProcessed))
            {
                lastTurnProcessed = new EventLine(lastEventProcessed).Turn;
            }

            // Process new lines
            string lastLineProcessed = null;
            foreach (string eventLine in newEvents)
            {
                EventLine evt = new EventLine(eventLine);
                if (evt.Turn > lastTurnProcessed)
                {
                    if (!SendTurnRollEmail(evt.Turn)) return lastLineProcessed;
                    lastTurnProcessed = evt.Turn;
                }
                else if (evt.Turn >= 0 && evt.Turn < lastTurnProcessed)
                {
                    if (!SendReloadDetectedEmail(evt.Turn)) return lastLineProcessed;
                    lastTurnProcessed = evt.Turn;
                }
                lastLineProcessed = eventLine;
            }
            return lastLineProcessed;
        }

        private static bool SendTurnRollEmail(int turn)
        {
            string subject = GetSetting("TurnRollSubject", "Turn {0} has begun");
            subject = string.Format(subject, turn);
            string message = GetSetting("TurnRollMessage", "Turn has rolled to turn {0}.");
            message = string.Format(message, turn);
            return SendEmailNotifications(turn, "Turn roll", subject, message);
        }

        private static bool SendReloadDetectedEmail(int turn)
        {
            string subject = GetSetting("ReloadSubject", "Game reloaded to turn {0}");
            subject = string.Format(subject, turn);
            string message = GetSetting("ReloadMessage", "A reload to turn {0} has been detected.");
            message = string.Format(message, turn);
            return SendEmailNotifications(turn, "Reload", subject, message);
        }

        private static bool SendEmailNotifications(int turn, string notificationType, string subject, string message)
        {
            Console.WriteLine(notificationType + " to turn " + turn + " detected. Sending email notifications...");
            try
            {
                string recipients = GetSetting("Recipients", null);
                if (!string.IsNullOrEmpty(recipients))
                {
                    _Emailer.SendEmails(GetSetting("FromAddress", "pitboss-portal@caledorn.no-ip.org"), recipients.Split(';'), subject, message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.ToString());
                return false;
            }
            Console.WriteLine("Email notifications sent successfully.");
            return true;
        }
    }
}
