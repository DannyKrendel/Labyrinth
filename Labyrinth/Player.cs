using System;
using System.Collections.Generic;
using System.Linq;

namespace Labyrinth
{
    class Player : Point
    {
        List<Cell> walls;

        public Player(char value, List<Cell> walls) : base(value, 1, 1)
        {
            this.walls = walls;
        }

        public void HandleKey(ConsoleKeyInfo cki)
        {
            switch (cki.Key)
            {
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    Y += 1;
                    if (IsCollidingWithWall())
                        Y -= 1;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    Y -= 1;
                    if (IsCollidingWithWall())
                        Y += 1;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    X += 1;
                    if (IsCollidingWithWall())
                        X -= 1;
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    X -= 1;
                    if (IsCollidingWithWall())
                        X += 1;
                    break;
            }
        }

        public bool IsCollidingWithWall()
        {
            return walls.Any(c => c.IsCollidingWith(this));
        }
    }
}
