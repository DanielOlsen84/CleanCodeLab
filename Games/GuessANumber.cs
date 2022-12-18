using CleanCodeLab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Games
{
    public class GuessANumber : IGame
    {
        public string GameTitle { get; set; }
        public int SecretNumber { get; set; }
        public int MaxNumber { get; set; }
        public bool IsPracticeMode { get; set; }

        public GuessANumber(bool isPracticeMode, int maxNumber = 100)
        {
            GameTitle = "Guess A Number";
            SecretNumber = GetRandomNumber(maxNumber);
            IsPracticeMode = isPracticeMode;
            MaxNumber = maxNumber;
        }

        public int GetRandomNumber(int max) => new Random().Next(max + 1);
        
        public void Start(string playerName)
        {
            Console.WriteLine($"{playerName} started a new game of {GameTitle}.");

            if (IsPracticeMode)
            {
                Console.WriteLine("For practice, number is: " + SecretNumber + "\n");
            }

            var guess = GetInput();
            int guesses = 1;
            
            while (guess != SecretNumber)
            {
                Console.WriteLine(guess > SecretNumber ? "You guessed too high!" : "You guessed too low.");
                guesses++;
                Console.WriteLine("Guess again:");
                guess = GetInput();                                
            }

            TopList.SaveToTopList(playerName, guesses);

            Console.WriteLine($"Correct, it took {guesses} guesses!");
        }

        private int GetInput()
        {
            do
            {
                var isGuessOk = int.TryParse(Console.ReadLine(), out int guess);

                if (isGuessOk)
                {
                    return guess;
                }
                else
                {
                    Console.WriteLine("Please input a valid number.");
                }
            }
            while (true);
        }

    }
}
