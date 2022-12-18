using CleanCodeLab.Games;
using CleanCodeLab.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace CleanCodeLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var quit = false;

            Console.WriteLine("Enter your user name:\n");
            string playerName = Console.ReadLine();

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
                    1 => new MooGame(false, true),
                    2 => new GuessANumber(true),
                };

                game.Start(playerName);

                TopList.PrintTopList();

                Console.WriteLine("Enter N to quit or enter any other key to play again.");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "n")
                {
                    quit = true;
                }
            }
        }
    }
}