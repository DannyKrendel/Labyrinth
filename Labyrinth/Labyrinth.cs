using System;
using System.Collections.Generic;
using System.Linq;

namespace Labyrinth
{
    class Labyrinth
    {
        public static List<Cell> CellList;
        public static List<Point> WallList;

        public static int Width { get; set; }
        public static int Height { get; set; }

        Cell currentCell;

        Stack<Cell> stack = new Stack<Cell>();

        public Labyrinth(int width, int height)
        {
            CellList = new List<Cell>();
            WallList = new List<Point>();

            Width = width;
            Height = height;

            // Точки
            for (int i = 1; i < Height * 2; i += 2)
            {
                for (int j = 1; j < Width * 2; j += 2)
                {
                    Cell c = new Cell(j, i);
                    CellList.Add(c);
                }
            }
            // Стены
            for (int i = 0; i < Height * 2 + 1; i++)
            {
                for (int j = 0; j < Width * 2 + 1; j++)
                {
                    Point p = new Point(j, i, ' ');
                    WallList.Add(p);
                }
            }

            currentCell = CellList.First();
        }

        public void DrawWalls()
        {
            foreach (Point p in WallList)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                p.Draw();
                Console.ResetColor();
            }
        }

        public void Draw()
        {
            currentCell.isVisited = true;

            Cell nextCell = currentCell.CheckNeighbors();

            if (nextCell != null)
            {
                RemoveWalls(currentCell, nextCell);
            }

            WallList.RemoveAll(p => p.x == currentCell.X && p.y == currentCell.Y);
            currentCell.Draw();

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
        }

        public static int Index(int x, int y)
        {
            return x + y * Width;
        }

        public void RemoveWalls(Cell a, Cell b)
        {
            int x = a.X - b.X;
            int y = a.Y - b.Y;

            if (x == 2)
            {
                WallList.RemoveAll(p => p.x == a.X - 1 && p.y == a.Y);
                a.walls[(int)Direction.Left] = false;
                b.walls[(int)Direction.Right] = false;
            }
            else if (x == -2)
            {
                WallList.RemoveAll(p => p.x == a.X + 1 && p.y == a.Y);
                a.walls[(int)Direction.Right] = false;
                b.walls[(int)Direction.Left] = false;
            }

            if (y == 2)
            {
                WallList.RemoveAll(p => p.x == a.X && p.y == a.Y - 1);
                a.walls[(int)Direction.Top] = false;
                b.walls[(int)Direction.Bottom] = false;
            }
            else if (y == -2)
            {
                WallList.RemoveAll(p => p.x == a.X && p.y == a.Y + 1);
                a.walls[(int)Direction.Bottom] = false;
                b.walls[(int)Direction.Top] = false;
            }
        }

        public bool IsCompleted()
        {
            return stack.Count == 0;
        }
    }
}