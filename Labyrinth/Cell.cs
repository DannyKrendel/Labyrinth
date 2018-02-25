using System;
using System.Collections.Generic;

namespace Labyrinth
{
    class Cell : Color
    {
        int x;
        int y;

        public int X
        {
            get => x * 2 + 1;
            set => x = value / 2;
        }
        public int Y
        {
            get => y * 2 + 1;
            set => y = value / 2;
        }

        public bool[] walls;

        public bool isVisited;

        public Cell(int x, int y)
        {
            X = x;
            Y = y;

            walls = new bool[] { true, true, true, true };

            isVisited = false;
        }

        public void Display()
        {
            Console.SetCursorPosition(X, Y);
            if (isVisited)
                ColorDisplay(" ", ConsoleColor.DarkGreen, ConsoleColor.DarkGreen);

            ColorDisplay(" ", Console.ForegroundColor, Console.BackgroundColor);

            DisplayWalls();
        }

        void DisplayWalls()
        {
            Point p = new Point();

            for (int i = 0; i < walls.Length; i++)
            {
                if (i == (int)Direction.Top)
                    p = new Point(' ', X, Y - 1);
                else if (i == (int)Direction.Right)
                    p = new Point(' ', X + 1, Y);
                else if (i == (int)Direction.Bottom)
                    p = new Point(' ', X, Y + 1);
                else if (i == (int)Direction.Left)
                    p = new Point(' ', X - 1, Y);

                if (walls[i])
                    p.Display(Console.ForegroundColor, Console.BackgroundColor);
                else
                    p.Display(ConsoleColor.DarkGreen, ConsoleColor.DarkGreen);
            }
        }

        internal void Highlight()
        {
            Point p = new Point(' ', X, Y);
            p.Display(ConsoleColor.Green, ConsoleColor.Green);
        }

        internal Cell CheckNeighbors()
        {
            Random rand = new Random();

            List<Cell> neighbors = new List<Cell>();

            Cell top = (y - 1 >= 0 && y - 1 < Labyrinth.Height) ? Labyrinth.CellList[x + (y - 1) * Labyrinth.Width] : null;
            Cell right = (x + 1 >= 0 && x + 1 < Labyrinth.Width) ? Labyrinth.CellList[x + 1 + y * Labyrinth.Width] : null;
            Cell bottom = (y + 1 >= 0 && y + 1 < Labyrinth.Height) ? Labyrinth.CellList[x + (y + 1) * Labyrinth.Width] : null;
            Cell left = (x - 1 >= 0 && x - 1 < Labyrinth.Width) ? Labyrinth.CellList[x - 1 + y * Labyrinth.Width] : null;

            if (top != null && !top.isVisited)
            {
                neighbors.Add(top);
            }
            if (right != null && !right.isVisited)
            {
                neighbors.Add(right);
            }
            if (bottom != null && !bottom.isVisited)
            {
                neighbors.Add(bottom);
            }
            if (left != null && !left.isVisited)
            {
                neighbors.Add(left);
            }

            if (neighbors.Count > 0)
            {
                int r = rand.Next(0, neighbors.Count);
                return neighbors[r];
            }
            return null;
        }
    }
}
