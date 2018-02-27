using System;

namespace Labyrinth
{
    class Cell : Point
    {
        public bool[] walls;

        public bool isVisited;

        public Cell() { }

        public Cell(int x, int y) : base(' ', x, y)
        {
            walls = new bool[] { true, true, true, true };

            isVisited = false;
        }

        public void Display()
        {
            if (isVisited)
                Display(ConsoleColor.DarkGreen, ConsoleColor.DarkGreen);
            else
                Display(Console.ForegroundColor, Console.BackgroundColor);

            DisplayWalls();
        }

        void DisplayWalls()
        {
            Cell c = new Cell();

            for (int i = 0; i < walls.Length; i++)
            {
                if      (i == (int)Direction.Top)
                    c = new Cell(X - 1, Y);
                else if (i == (int)Direction.Right)
                    c = new Cell(X, Y + 1);
                else if (i == (int)Direction.Bottom)
                    c = new Cell(X + 1, Y);
                else if (i == (int)Direction.Left)
                    c = new Cell(X, Y - 1);

                if (walls[i])
                    c.Display(Console.ForegroundColor, Console.BackgroundColor);
                else
                    c.Display(ConsoleColor.DarkGreen, ConsoleColor.DarkGreen);
            }
        }

        public void Highlight()
        {
            Display(ConsoleColor.Green, ConsoleColor.Green);
        }
    }
}
