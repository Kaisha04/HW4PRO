using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace task2
{
    class Program
    {
        public static string pathToSite = @"C:\Users\adm.fenovka\Documents\Lessons\HW4\task2\site.txt";
        public static string pathToResult = @"C:\Users\adm.fenovka\Documents\Lessons\HW4\task2\result.txt";
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>()
            {
              {"URL", new List<string>()},
              {"Phone", new List<string>()},
              {"Email", new List<string>()}
            };
            StringBuilder text = new StringBuilder();
            if (File.Exists(pathToSite))
            {
                using (StreamReader sReader = new StreamReader(pathToSite))
                {
                    text.Append(sReader.ReadToEnd());
                }
            }
            else return;

            string urlPattern = @"(http|https):\/\/([\w-]+(\.[\w-]+)+)([\w.,@?^=%&amp;:/~+#-]*[\w@?^=%&amp;/~+#-])?";
            string numberPattern = @"\+?380\s?\(?\d{2}\)?\s?\d{3}[-\s]?\d{2}[-\s]?\d{2}";
            string emailPattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";

            foreach (Match match in Regex.Matches(text.ToString(), urlPattern))
            {
                data["URL"].Add(match.Value);

            }

            foreach (Match match in Regex.Matches(text.ToString(), numberPattern))
            {
                data["Phone"].Add(match.Value);
            }

            foreach (Match match in Regex.Matches(text.ToString(), emailPattern))
            {
                data["Email"].Add(match.Value);
            }
            using (StreamWriter writer = new StreamWriter(pathToResult, false))
            {
            }
            using (StreamWriter sWriter = new StreamWriter(pathToResult))
            {
                foreach (var item in data)
                {
                    sWriter.WriteLine(item.Key + ":");

                    foreach (var value in item.Value)
                    {
                        sWriter.WriteLine(value);
                    }

                    sWriter.WriteLine();
                }
            }

        }
    }
}