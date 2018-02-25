using System;
using System.Linq;

namespace Labyrinth
{
    class Player : Point
    {
        public char Value { get => value; set => base.value = value; }

        public int X
        {
            get => x;
            set
            {
                if (!Labyrinth.WallList.Any(p => p.x == value && p.y == y))
                    x = value;
            }
        }

        public int Y
        {
            get => y;
            set
            {
                if (!Labyrinth.WallList.Any(p => p.y == value && p.x == x))
                    y = value;
            }
        }

        Point startPoint;
        Point endPoint;

        public Player(char value)
        {
            Value = value;
            X = 1;
            Y = 1;

            startPoint = new Point(' ', X, Y);
            endPoint = new Point(' ', Labyrinth.Width * 2 - 1, Labyrinth.Height * 2 - 1);
        }

        public void Update()
        {
            startPoint.Display(Console.ForegroundColor, ConsoleColor.Green);
            endPoint.Display(Console.ForegroundColor, ConsoleColor.Red);
            

            if (Console.KeyAvailable == true)
            {
                Erase(ConsoleColor.Green, ConsoleColor.DarkGreen);

                ConsoleKeyInfo cki = Console.ReadKey(true);

                switch (cki.Key)
                {
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        X += 1;
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        X -= 1;
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        Y += 1;
                        break;
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        Y -= 1;
                        break;
                }
                Display(Console.ForegroundColor, Console.BackgroundColor);
            }
        }

        public bool IsFinished()
        {
            return IsCollidingWith(endPoint);
        }
    }
}
