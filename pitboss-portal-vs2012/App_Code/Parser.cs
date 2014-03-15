using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace pitboss_portal
{
    public class Parser
    {
        public static string GetSetting(string key, string defaultValue)
        {
            string value = System.Web.Configuration.WebConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(value)) return defaultValue;
            return value;
        }

        public static List<string> ReadFile(string filepath, int cutoff)
        {
            if (!Path.IsPathRooted(filepath))
            {
                filepath = HttpContext.Current.Server.MapPath(filepath);
            }
            List<string> lines = new List<string>();
            StreamReader r = null;
            try
            {
                r = new StreamReader(filepath);
                string line = r.ReadLine();
                while (!string.IsNullOrEmpty(line) && (cutoff == 0 || cutoff > lines.Count))
                {
                    lines.Add(line);
                    line = r.ReadLine();
                }
                return lines;
            }
            finally
            {
                if (r != null) r.Close();
            }
        }
    }
}