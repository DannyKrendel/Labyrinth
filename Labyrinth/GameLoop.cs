using System;
using System.Diagnostics;
using System.Threading;

namespace Labyrinth
{
    class GameLoop : IGameLoop
    {
        Stopwatch stopwatch;

        public void Run(IGame game)
        {
            stopwatch = new Stopwatch();

            // Display generation of a labyrinth
            game.DisplayField();

            // Start timer
            stopwatch.Start();

            do
            {
                if (Console.KeyAvailable == true)
                {
                    game.HandleKey(Console.ReadKey(true));
                    game.DisplayPlayer();
                }
            } while (!game.IsWon());

            // Stop timer
            stopwatch.Stop();

            Thread.Sleep(500);

            TimeSpan time = stopwatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}.{2:00}", time.Minutes, time.Seconds, time.Milliseconds / 10);

            // Show elapsed time
            Console.WriteLine("\nYou've completed a labyrinth in {0}!\n", elapsedTime);
            Console.WriteLine("Press any button to continue or Escape to quit to menu.");

            ConsoleKeyInfo cki = Console.ReadKey(true);
            Console.Clear();

            if (cki.Key != ConsoleKey.Escape)
                Run(game);
        }
    }
}
