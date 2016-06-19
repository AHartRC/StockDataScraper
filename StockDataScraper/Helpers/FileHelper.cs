#region Using Directives

using System;
using System.IO;
using System.Linq;

#endregion

namespace StockDataScraper.Helpers
{
    public class FileHelper
    {
        public static void WriteToFile(FileInfo file, string response)
        {
            if (string.IsNullOrWhiteSpace(response))
                return;

            if (file.Directory == null)
                throw new ArgumentException();

            if (file.Directory != null && !file.Directory.Exists)
                file.Directory.Create();

            using (var fs = File.Create(file.FullName))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine(response);
                }
            }
        }

        public static void AppendToFile(FileInfo file, string response)
        {
            AppendToFile(file, new[] {response});
        }

        public static void AppendToFile(FileInfo file, string[] responses)
        {
            if (responses == null || !responses.Any())
                return;

            if (file.Directory == null || !file.Directory.Exists || !file.Exists)
            {
                WriteToFile(file, responses[0]);

                if (responses.Length > 1)
                    File.AppendAllLines(file.FullName, responses.Skip(1));
            }
            else
            {
                File.AppendAllLines(file.FullName, responses);
            }
        }
    }
}