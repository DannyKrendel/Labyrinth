using System;

namespace Labyrinth
{
    class Game : IGame
    {
        public int Height { get; }
        public int Width { get; }
        public char PlayerSym { get; }
        public int GenSpeed { get; }

        Labyrinth labyrinth;
        Player player;

        Cell Start { get; }
        Cell End { get; }

        public Game(int height, int width, char playerSym, int genSpeed)
        {
            Height = height;
            Width = width;
            PlayerSym = playerSym;
            GenSpeed = genSpeed;

            Start = new Cell(1, 1);
            End = new Cell(Height - 2, Width - 2);
        }

        // Display field, each time generating a new one
        public void DisplayField()
        {
            labyrinth = new Labyrinth(Height, Width);
            player = new Player(PlayerSym, labyrinth.Walls);

            labyrinth.Generate(GenSpeed);

            Start.Display(Console.ForegroundColor, ConsoleColor.Green);
            End.Display(Console.ForegroundColor, ConsoleColor.Red);
        }

        // Display player cell
        public void DisplayPlayer()
        {
            player.Display(Console.ForegroundColor, Console.BackgroundColor);
        }

        // Move player
        public void HandleKey(ConsoleKeyInfo cki)
        {
            player.Erase(ConsoleColor.Green, ConsoleColor.DarkGreen);
            player.HandleKey(cki);
        }

        // Game is won when player gets to end cell
        public bool IsWon()
        {
            return player.IsCollidingWith(End);
        }
    }
}
