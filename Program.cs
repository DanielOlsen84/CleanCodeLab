using CleanCodeLab.Games;
using CleanCodeLab.Interfaces;

namespace CleanCodeLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var quit = false;

            Console.WriteLine("Enter your user name:\n");
            var playerName = Console.ReadLine();

            ITopList topList = new TopList();

            while (!quit)
            {
                Console.Clear();
                
                var selectedGame = Menues.RunGameSelectionMenu(playerName);
                
                if (selectedGame == 0)
                {
                    return;
                }

                IGame game = selectedGame switch
                {
                    1 => new MooGame(topList, false, false),
                    2 => new GuessANumber(topList, false),
                };

                game.Start(playerName);

                topList.PrintTopList(game.GameName);

                Console.WriteLine("Enter N to quit or enter any other key to play again.");
                var answer = Console.ReadLine();
                if (answer.ToLower() == "n")
                {
                    quit = true;
                }
            }
        }
    }
}