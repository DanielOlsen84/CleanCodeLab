using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class Menues
    {
        public static int RunGameSelectionMenu(string playerName)
        {
            Console.WriteLine($"Hello {playerName}! Which game would you like to play?");
            Console.WriteLine("Choose by entering a number:");
            Console.WriteLine();
            Console.WriteLine("1: Moo Game");
            Console.WriteLine("2: Guess A Number");
            Console.WriteLine();
            Console.WriteLine("0: Exit application");

            return GetInputInteger(new int[] { 1, 2, 0 });
        }

        public static int GetInputInteger(int[] validInts)
        {
            do
            {
                var isInputOk = int.TryParse(Console.ReadLine(), out int input);

                if (isInputOk && validInts.Contains(input))
                {
                    return input;
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
