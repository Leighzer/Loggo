using System;
using System.IO;
using System.Reflection;

namespace Loggo
{
    public class Program
    {
        private static readonly string s_appDir = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath);

        public static void Main(string[] args)
        {
            try
            {
                string logNote = string.Join(' ', args);

                var now = DateTime.Now;
                string todayString = now.ToString("yyyyMMdd");

                string logTime = now.ToString("yyyyMMdd hh:mm:ss.fff");

                string logLine = logTime + " " + logNote;

                // ensure there is a log directory to write files to
                Directory.CreateDirectory($"{s_appDir}/logs");

                string path = $"{s_appDir}/logs/{todayString}.txt";
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(logLine);
                }

                Console.WriteLine($"Log line successfully added to {todayString}.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
