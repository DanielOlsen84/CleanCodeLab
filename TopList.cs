using CleanCodeLab.Interfaces;

namespace CleanCodeLab
{
    public class TopList : ITopList
    {
        private readonly string filePath = "result.txt";
        private readonly string delimiter = "#&#";
        public void SaveToTopList(string playerName, int guesses)
        {
            var stream = new StreamWriter(filePath, append: true);
            stream.WriteLine(playerName + delimiter + guesses);
            stream.Close();
        }

        public List<string> LoadTopList() => File.ReadAllLines(filePath).ToList();

        public List<string> GetTopList()
        {
            var results = new List<PlayerData>();
            
            foreach (var player in LoadTopList())
            {
                var nameAndScore = player.Split(new string[] { delimiter }, StringSplitOptions.None);
                var name = nameAndScore[0];
                var guesses = Convert.ToInt32(nameAndScore[1]);
                var playerData = new PlayerData(name, guesses);
                int position = results.IndexOf(playerData);
                if (position < 0)
                {
                    results.Add(playerData);
                }
                else
                {
                    results[position].Update(guesses);
                }
            }
                        
            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));

            return results.Select(x => string.Format("{0,-9}{1,5:D}{2,9:F2}", x.Name, x.TotalGames, x.Average())).ToList();
        }

        public void PrintTopList()
        {
            Console.WriteLine("Player   games average");
            GetTopList().ForEach(x => Console.WriteLine(x));
        }
    }
}
