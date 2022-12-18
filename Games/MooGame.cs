using CleanCodeLab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Games
{
    public class MooGame : IGame
    {
        public string GameTitle { get; set; }
        public string SecretNumber { get; set; }
        public bool IsPracticeMode { get; set; }
        public bool AllowDoubles { get; set; }

        public MooGame(bool allowDoubles, bool isPracticeMode)
        {
            GameTitle = "Moo Game";
            SecretNumber = GetRandomDigits();
            IsPracticeMode = isPracticeMode;
            AllowDoubles = allowDoubles;
        }

        public void Start(string playerName)
        {
            Console.WriteLine($"{playerName} started a new game of {GameTitle}.");
            Console.WriteLine($"Repeating numbers {(AllowDoubles ? "might" : "does not")} exist.");

            if (IsPracticeMode)
            {
                Console.WriteLine("For practice, number is: " + SecretNumber + "\n");
            }

            var guess = Console.ReadLine();

            var guesses = 1;
            var bullAndCows = CheckBullsAndCows(SecretNumber, guess);
            Console.WriteLine(bullAndCows + "\n");
            while (bullAndCows != "BBBB,")
            {
                guesses++;
                guess = Console.ReadLine();
                Console.WriteLine(guess + "\n");
                bullAndCows = CheckBullsAndCows(SecretNumber, guess);
                Console.WriteLine(bullAndCows + "\n");
            }

            TopList.SaveToTopList(playerName, guesses);

            Console.WriteLine($"Correct, it took {guesses} guesses!");
        }

        public string GetRandomDigits()
        {
            var random = new Random();

            var digits = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var result = string.Empty;

            for (int i = 0; i < 4; i++)
            {
                var randomInt = random.Next(digits.Count);
                result += digits[randomInt].ToString();

                if (!AllowDoubles)
                {
                    digits.Remove(randomInt);
                }
            }

            return result;
        }

        public string CheckBullsAndCows(string goal, string guess)
        {
            int cows = 0, bulls = 0;
            guess += "    ";     // if player entered less than 4 chars
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (goal[i] == guess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
        }
    }
}
