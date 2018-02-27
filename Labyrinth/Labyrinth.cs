using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Labyrinth
{
    class Labyrinth
    {
        public int Height { get; }
        public int Width { get; }

        public List<Cell> Cells { get; }
        public List<Cell> Walls { get; }

        public Cell StartCell { get; }
        public Cell EndCell { get; }

        Cell currentCell;

        Stack<Cell> stack = new Stack<Cell>();

        public Labyrinth(int height, int width)
        {
            Cells = new List<Cell>();
            Walls = new List<Cell>();

            Height = height % 2 == 0 ? height - 1 : height;
            Width = width % 2 == 0 ? width - 1 : width;

            // Adding cells
            for (int i = 1; i < Height; i += 2)
            {
                for (int j = 1; j < Width; j += 2)
                {
                    Cells.Add(new Cell(i, j));
                }
            }

            // Adding walls
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Walls.Add(new Cell(i, j));
                }
            }

            currentCell = Cells.First();

            StartCell = new Cell(1, 1);
            EndCell = new Cell(Height - 2, Width - 2);
        }

        public void Generate(int latency)
        {
            do
            {
                currentCell.isVisited = true;

                Cell nextCell = GetNeighbor(currentCell);

                if (nextCell != null)
                    RemoveWalls(currentCell, nextCell);

                foreach (Cell wall in Walls)
                {
                    if (wall.X == currentCell.X && wall.Y == currentCell.Y)
                    {
                        Walls.Remove(wall);
                        break;
                    }
                }

                currentCell.Display();

                if (nextCell != null)
                {
                    stack.Push(currentCell);
                    nextCell.isVisited = true;
                    currentCell = nextCell;
                }
                else if (stack.Count > 0)
                {
                    currentCell = stack.Pop();
                }

                currentCell.Highlight();

                Thread.Sleep(latency);

            } while (!IsCompleted());

            // Display walls
            foreach (Cell c in Walls)
                c.Display(ConsoleColor.DarkBlue, ConsoleColor.DarkBlue);

            StartCell.Display(Console.ForegroundColor, ConsoleColor.Green);
            EndCell.Display(Console.ForegroundColor, ConsoleColor.Red);
        }

        void RemoveWalls(Cell a, Cell b)
        {
            int x = (a.X != b.X) ? (a.X > b.X ? a.X - 1 : a.X + 1) : a.X;
            int y = (a.Y != b.Y) ? (a.Y > b.Y ? a.Y - 1 : a.Y + 1) : a.Y;

            foreach (Cell wall in Walls)
            {
                if (wall.X == x && wall.Y == y)
                {
                    Walls.Remove(wall);
                    break;
                }
            }

            if (a.X - b.X == 2)
            {
                a.walls[(int)Direction.Top] = false;
                b.walls[(int)Direction.Bottom] = false;
            }
            else if (a.X - b.X == -2)
            {
                a.walls[(int)Direction.Bottom] = false;
                b.walls[(int)Direction.Top] = false;
            }

            if (a.Y - b.Y == 2)
            {
                a.walls[(int)Direction.Left] = false;
                b.walls[(int)Direction.Right] = false;
            }
            else if (a.Y - b.Y == -2)
            {
                a.walls[(int)Direction.Right] = false;
                b.walls[(int)Direction.Left] = false;
            }
        }

        Cell GetNeighbor(Cell cell)
        {
            Random rand = new Random();

            List<Cell> neighbors = new List<Cell>();

            Cell top = (cell.X - 2 > 0) ? Cells.Find(c => c.X == cell.X - 2 && c.Y == cell.Y) : null;
            Cell right = (cell.Y + 2 < Width - 1) ? Cells.Find(c => c.Y == cell.Y + 2 && c.X == cell.X) : null;
            Cell bottom = (cell.X + 2 < Height - 1) ? Cells.Find(c => c.X == cell.X + 2 && c.Y == cell.Y) : null;
            Cell left = (cell.Y - 2 > 0) ? Cells.Find(c => c.Y == cell.Y - 2 && c.X == cell.X) : null;

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
                int index = rand.Next(neighbors.Count);
                return neighbors[index];
            }
            return null;
        }

        bool IsCompleted()
        {
            return stack.Count == 0;
        }
    }
}