using CleanCodeLab.Enums;
using CleanCodeLab.Interfaces;

namespace CleanCodeLab.Games
{
    public class GuessANumber : IGame
    {
        private readonly ITopList _topList;
        
        public string GameTitle { get; set; }
        public int SecretNumber { get; set; }
        public int MaxNumber { get; set; }
        public bool IsPracticeMode { get; set; }
        public GameNameEnum.GameName GameName { get; set; } = GameNameEnum.GameName.GuessANumber;

        public GuessANumber(ITopList topList, bool isPracticeMode, int maxNumber = 100)
        {
            GameTitle = "Guess A Number";
            SecretNumber = GetRandomNumber(maxNumber);
            IsPracticeMode = isPracticeMode;
            MaxNumber = maxNumber;
            _topList = topList;
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
            var guesses = 1;
            
            while (guess != SecretNumber)
            {
                Console.WriteLine(guess > SecretNumber ? "You guessed too high!" : "You guessed too low.");
                guesses++;
                Console.WriteLine("Guess again:");
                guess = GetInput();
            }

            _topList.SaveToTopList(GameName, playerName, guesses);

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
