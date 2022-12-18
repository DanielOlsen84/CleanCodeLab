using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class TopList
    {
        private static readonly string filePath = "result.txt";
        private static readonly string delimiter = "#&#";
        public static void SaveToTopList(string playerName, int guesses)
        {
            var stream = new StreamWriter(filePath, append: true);
            stream.WriteLine(playerName + delimiter + guesses);
            stream.Close();
        }

        public static List<string> LoadTopList() => File.ReadAllLines(filePath).ToList();

        public static List<string> GetTopList()
        {
            var results = new List<PlayerData>();
            
            foreach (var player in LoadTopList())
            {
                string[] nameAndScore = player.Split(new string[] { delimiter }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData pd = new PlayerData(name, guesses);
                int pos = results.IndexOf(pd);
                if (pos < 0)
                {
                    results.Add(pd);
                }
                else
                {
                    results[pos].Update(guesses);
                }
            }
                        
            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));

            return results.Select(x => string.Format("{0,-9}{1,5:D}{2,9:F2}", x.Name, x.TotalGames, x.Average())).ToList();
        }

        public static void PrintTopList()
        {
            Console.WriteLine("Player   games average");
            GetTopList().ForEach(x => Console.WriteLine(x));
        }
    }
}
