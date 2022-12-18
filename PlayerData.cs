using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class PlayerData
    {
        public string Name { get; private set; }
        public int TotalGames { get; private set; }
        public int TotalGuesses { get; private set; }

        public PlayerData(string name, int guesses)
        {
            Name = name;
            TotalGames = 1;
            TotalGuesses = guesses;
        }

        public void Update(int guesses)
        {
            TotalGuesses += guesses;
            TotalGames++;
        }

        public double Average()
        {
            return (double)TotalGuesses / TotalGames;
        }
    }
}
