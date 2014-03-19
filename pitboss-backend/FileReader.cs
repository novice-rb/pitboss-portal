using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace pitboss_backend
{
    public class FileReader
    {
        public static List<string> ReadFile(string filepath, int cutoff)
        {
            List<string> lines = new List<string>();
            StreamReader r = null;
            try
            {
                bool lastLine = false;
                r = new StreamReader(filepath);
                string line = r.ReadLine();
                while (line != null && !lastLine && (cutoff == 0 || cutoff > lines.Count))
                {
                    line = line.Trim(' ', '\0', '\r');
                    if (line == "---LAST LINE---")
                    {
                        lastLine = true;
                    }
                    else if (line != "")
                    {
                        lines.Add(line);
                    }
                    line = r.ReadLine();
                }
                return lines;
            }
            finally
            {
                if (r != null) r.Close();
            }
        }

        public static void WriteFile(string filepath, List<string> lines)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filepath, false);
                foreach (var line in lines)
                    writer.WriteLine(line);
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }

    }

}