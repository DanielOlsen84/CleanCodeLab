using CleanCodeLab.Enums;
using CleanCodeLab.Interfaces;

namespace CleanCodeLab
{
    public class TopList : ITopList
    {
        private readonly string mooGameFilePath = "MooGameResult.txt";
        private readonly string guessANumberFilePath = "GuessANumberResult.txt";
        private readonly string delimiter = "#&#";
        public void SaveToTopList(GameNameEnum.GameName gameName, string playerName, int guesses)
        {
            var filePath = gameName switch
            {
                GameNameEnum.GameName.MooGame => mooGameFilePath,
                GameNameEnum.GameName.GuessANumber => guessANumberFilePath,
            };

            var stream = new StreamWriter(filePath, append: true);
            stream.WriteLine(playerName + delimiter + guesses);
            stream.Close();
        }

        public List<string> LoadTopList(string filePath) => File.ReadAllLines(filePath).ToList();

        public List<string> GetTopList(GameNameEnum.GameName gameName)
        {
            var results = new List<PlayerData>();

            var filePath = gameName switch
            {
                GameNameEnum.GameName.MooGame => mooGameFilePath,
                GameNameEnum.GameName.GuessANumber => guessANumberFilePath,
            };

            foreach (var player in LoadTopList(filePath))
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

        public void PrintTopList(GameNameEnum.GameName gameName)
        {
            Console.WriteLine("Player   games average");
            GetTopList(gameName).ForEach(x => Console.WriteLine(x));
        }
    }
}
