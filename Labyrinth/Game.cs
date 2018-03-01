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

            Initialize();

            Start = new Cell(1, 1);
            End = new Cell(Height - 2, Width - 2);
        }

        public void Initialize()
        {
            labyrinth = new Labyrinth(Height, Width, ConsoleColor.DarkGreen, ConsoleColor.DarkBlue);
            player = new Player(PlayerSym, labyrinth.Walls);
        }

        // Display field, each time generating a new one
        public void DisplayField()
        {
            labyrinth.Generate(GenSpeed);

            Start.Display(ConsoleColor.Green, ConsoleColor.Green);
            End.Display(ConsoleColor.Red, ConsoleColor.Red);
        }

        // Display player cell
        public void DisplayPlayer()
        {
            player.Display(ConsoleColor.Green, ConsoleColor.DarkMagenta);
        }

        // Move player
        public void HandleKey(ConsoleKeyInfo cki)
        {
            player.Erase(labyrinth.FieldColor, labyrinth.FieldColor);
            player.HandleKey(cki);
        }

        // Game is won when player gets to end cell
        public bool IsWon()
        {
            return player.IsCollidingWith(End);
        }
    }
}
