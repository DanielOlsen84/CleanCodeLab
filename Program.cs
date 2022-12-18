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

                var mooGame = new MooGame(false, true);
                mooGame.Start(playerName);

                TopList.PrintTopList();

                Console.WriteLine("Play again (Y/N)?");
                string answer = Console.ReadLine();
                if (answer != null && answer != "" && answer.Substring(0, 1).ToLower() == "n")
                {
                    quit = true;
                }
            }
        }
    }
}