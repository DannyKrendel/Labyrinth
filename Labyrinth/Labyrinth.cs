using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Labyrinth
{
    class Labyrinth
    {
        // Field parameters
        public int Height { get; }
        public int Width { get; }

        // Cells for player to move on
        public List<Cell> Cells { get; }
        // Walls to form an actual labyrinth
        public List<Cell> Walls { get; }

        // Beginning generation with this cell
        Cell currentCell;

        // Stack for recursive generation algorithm
        Stack<Cell> stack = new Stack<Cell>();

        // Colors
        public ConsoleColor FieldColor { get; }
        public ConsoleColor WallsColor { get; }

        public Labyrinth(int height, int width, ConsoleColor fieldColor, ConsoleColor wallsColor)
        {
            Cells = new List<Cell>();
            Walls = new List<Cell>();

            // Setting an odd number even if it's even
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

            // Adding colors
            FieldColor = fieldColor;
            WallsColor = wallsColor;

            // Always beginning generation with a first cell (1, 1)
            currentCell = Cells.First();
        }

        // Generating a labyrinth with latency to see the process
        public void Generate(int latency)
        {
            do
            {
                // Always marking current cell as visited
                currentCell.isVisited = true;

                // Getting random neighbor cell as a next one
                Cell nextCell = GetNeighbor(currentCell);

                // If there is at least one available neighbor - remove walls between current and next cell
                if (nextCell != null)
                    RemoveWalls(currentCell, nextCell);

                // Removing wall that is equal to current cell
                foreach (Cell wall in Walls)
                {
                    if (wall.X == currentCell.X && wall.Y == currentCell.Y)
                    {
                        Walls.Remove(wall);
                        break;
                    }
                }

                currentCell.Display(FieldColor);

                // If there is available next cell - pushing current cell to stack and assigning next to current
                // Else - backtracking to cell that has at least one available neighbor
                if (nextCell != null)
                {
                    stack.Push(currentCell);
                    currentCell = nextCell;
                }
                else if (stack.Count > 0)
                    currentCell = stack.Pop();

                // Highlight current cell
                currentCell.Display(ConsoleColor.Green, ConsoleColor.Green);

                Thread.Sleep(latency);

                // Algorithm is done when current cell is back at the beginning
            } while (!IsCompleted());

            // Display walls
            foreach (Cell c in Walls)
                c.Display(WallsColor, WallsColor);
        }

        void RemoveWalls(Cell a, Cell b)
        {
            // Assigning coordinates of a wall between a and b
            int x = (a.X != b.X) ? (a.X > b.X ? a.X - 1 : a.X + 1) : a.X;
            int y = (a.Y != b.Y) ? (a.Y > b.Y ? a.Y - 1 : a.Y + 1) : a.Y;

            // Removing wall
            foreach (Cell wall in Walls)
            {
                if (wall.X == x && wall.Y == y)
                {
                    Walls.Remove(wall);
                    break;
                }
            }

            // Disabling corresponding wall for each cell
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

            // Assigning available neighbor cells
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

            // Returning random neigbor from a list
            if (neighbors.Count > 0)
            {
                int index = rand.Next(neighbors.Count);
                return neighbors[index];
            }
            // Else return no neighbor
            return null;
        }

        // If stack is empty then labyrinth is generated successfully
        bool IsCompleted()
        {
            return stack.Count == 0;
        }
    }
}