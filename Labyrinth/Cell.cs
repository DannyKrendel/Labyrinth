using System;

namespace Labyrinth
{
    class Cell : Point
    {
        // 4 walls on each direction
        public bool[] walls;

        public bool isVisited;

        public Cell(int x, int y) : base(' ', x, y)
        {
            walls = new bool[] { true, true, true, true };

            isVisited = false;
        }

        public void Display(ConsoleColor bgColor)
        {
            // Not displaying cell that hasn't been visited
            if (isVisited)
                Display(Console.ForegroundColor, bgColor);
            else
                Display(Console.ForegroundColor, Console.BackgroundColor);

            // Displaying available walls around each cell
            DisplayWalls(bgColor);
        }

        void DisplayWalls(ConsoleColor bgColor)
        {
            Cell c = null;

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

                // If wall is enabled - don't display anything
                // If wall is disabled - display as normal cell
                if (walls[i])
                    c.Display(Console.ForegroundColor, Console.BackgroundColor);
                else
                    c.Display(Console.ForegroundColor, bgColor);
            }
        }

        public void Highlight()
        {
            Display(ConsoleColor.Green, ConsoleColor.Green);
        }
    }
}
