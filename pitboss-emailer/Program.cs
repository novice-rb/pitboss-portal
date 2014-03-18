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
                string binPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                filepath = System.IO.Path.Combine(binPath, filepath);
            }
            return filepath;
        }

        static void Main(string[] args)
        {
            List<string> emailerInfo = new List<string>();
            try
            {
                emailerInfo = FileReader.ReadFile(GetSettingPath("EmailerFile", "testdata/emailer.txt"), 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading emailer.txt: " + ex.ToString());
                return;
            }
            string lastEventProcessed = null;
            if(emailerInfo.Count > 0) lastEventProcessed = emailerInfo[0];

            List<string> eventInfo = new List<string>();
            try
            {
                eventInfo = FileReader.ReadFile(GetSettingPath("EventFile", "testdata/event.txt"), 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading event.txt: " + ex.ToString());
                return;
            }
            List<EventLine> eventLines = new List<EventLine>();
            foreach (string line in eventInfo)
            {
                if (!string.IsNullOrEmpty(lastEventProcessed) && line == lastEventProcessed) break;
                EventLine evt = new EventLine(line);
                eventLines.Add(evt);
            }
            int lastTurnProcessed = 0;
            if (!string.IsNullOrEmpty(lastEventProcessed))
            {
                lastTurnProcessed = new EventLine(lastEventProcessed).Turn;
            }
            eventLines.Reverse();
            foreach (var evt in eventLines)
            {
                if (evt.Turn > lastTurnProcessed)
                {
                    SendTurnRollEmail(evt.Turn);
                    lastTurnProcessed = evt.Turn;
                }
                else if (evt.Turn >= 0 && evt.Turn < lastTurnProcessed)
                {
                    SendReloadDetectedEmail(evt.Turn);
                    lastTurnProcessed = evt.Turn;
                }
            }
            Console.WriteLine("Done processing event log.");
        }

        private static void SendTurnRollEmail(int turn)
        {
            string subject = GetSetting("TurnRollSubject", "Turn {0} has begun");
            subject = string.Format(subject, turn);
            string message = GetSetting("TurnRollMessage", "Turn has rolled to turn {0}.");
            message = string.Format(message, turn);
            SendEmailNotifications(turn, "Turn roll", subject, message);
        }

        private static void SendReloadDetectedEmail(int turn)
        {
            string subject = GetSetting("ReloadSubject", "Game reloaded to turn {0}");
            subject = string.Format(subject, turn);
            string message = GetSetting("ReloadMessage", "A reload to turn {0} has been detected.");
            message = string.Format(message, turn);
            SendEmailNotifications(turn, "Reload", subject, message);
        }

        private static void SendEmailNotifications(int turn, string notificationType, string subject, string message)
        {
            Console.WriteLine(notificationType + " to turn " + turn + " detected. Sending email notifications...");
            try
            {
                string recipients = GetSetting("Recipients", null);
                if (!string.IsNullOrEmpty(recipients))
                {
                    EmailUtility emailer = new EmailUtility(GetSetting("SmtpServer", null), int.Parse(GetSetting("SmtpPort", "25")), GetSetting("SmtpUsername", null), GetSetting("SmtpPassword", null), GetSetting("SmtpDomain", null));
                    emailer.SendEmails(GetSetting("FromAddress", "pitboss-portal@caledorn.no-ip.org"), recipients.Split(';'), subject, message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.ToString());
            }
            Console.WriteLine("Email notifications sent successfully.");
        }
    }
}
