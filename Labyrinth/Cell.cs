using System;
using System.Collections.Generic;

namespace Labyrinth
{
    class Cell
    {
        private int x;
        private int y;

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

        public void Draw()
        {
            if (isVisited)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }

            Console.SetCursorPosition(X, Y);
            Console.Write(' ');

            Console.ResetColor();

            char c = ' ';

            // Отрисовка стен
            if (walls[(int)Direction.Top])
            {
                Point p = new Point(X, Y - 1, c);
                p.Draw();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Point p = new Point(X, Y - 1, c);
                p.Undraw();
                Console.ResetColor();
            }
            if (walls[(int)Direction.Right])
            {
                Point p = new Point(X + 1, Y, c);
                p.Draw();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Point p = new Point(X + 1, Y, c);
                p.Undraw();
                Console.ResetColor();
            }
            if (walls[(int)Direction.Bottom])
            {
                Point p = new Point(X, Y + 1, c);
                p.Draw();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Point p = new Point(X, Y + 1, c);
                p.Undraw();
                Console.ResetColor();
            }
            if (walls[(int)Direction.Left])
            {
                Point p = new Point(X - 1, Y, c);
                p.Draw();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Point p = new Point(X - 1, Y, c);
                p.Undraw();
                Console.ResetColor();
            }
        }

        internal void Highlight()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Green;
            Point p = new Point(X, Y, ' ');
            p.Draw();
            Console.ResetColor();
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
