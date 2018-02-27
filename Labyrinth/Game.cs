using System;
using System.Diagnostics;
using System.Threading;

namespace Labyrinth
{
    class Game : IGame
    {
        public int Height { get; }
        public int Width { get; }
        public char PlayerSym { get; }
        public int GenSpeed { get; }

        public Labyrinth labyrinth;
        public Player player;

        Stopwatch stopwatch = new Stopwatch();

        public Game(int height, int width, char playerSym, int genSpeed)
        {
            Height = height;
            Width = width;
            PlayerSym = playerSym;
            GenSpeed = genSpeed;
        }

        public bool Update()
        {
            labyrinth = new Labyrinth(Height, Width);
            player = new Player(PlayerSym, labyrinth.Walls);

            labyrinth.Generate(GenSpeed);

            stopwatch.Start();

            do
            {
                if (Console.KeyAvailable == true)
                {
                    player.Erase(ConsoleColor.Green, ConsoleColor.DarkGreen);

                    player.HandleKey(Console.ReadKey(true));

                    player.Display(Console.ForegroundColor, Console.BackgroundColor);
                }
            } while (!player.IsCollidingWith(labyrinth.EndCell));

            stopwatch.Stop();

            Thread.Sleep(500);
            Console.ResetColor();
            Console.Clear();

            TimeSpan time = stopwatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}.{2:00}", time.Minutes, time.Seconds, time.Milliseconds / 10);

            Console.WriteLine("You've competed labyrinth in {0}!", elapsedTime);
            Console.WriteLine("Press any button to continue or Escape to quit to menu.");

            ConsoleKeyInfo cki = Console.ReadKey(true);
            Console.Clear();

            stopwatch.Reset();

            if (cki.Key == ConsoleKey.Escape)
                return false;
            return true;
        }
    }
}
