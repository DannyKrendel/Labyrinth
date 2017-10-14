using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class Player : Point
    {
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

        public char Ch { get => ch; set => ch = value; }

        Point startPoint;
        Point endPoint;

        public Player(char ch)
        {
            startPoint = new Point(1, 1, ' ');
            endPoint = new Point(Labyrinth.Width * 2 - 1, Labyrinth.Height * 2 - 1, ' ');

            x = 1;
            y = 1;
            Ch = ch;
        }

        public void Update()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            startPoint.Draw();
            Console.BackgroundColor = ConsoleColor.Red;
            endPoint.Draw();
            

            if (Console.KeyAvailable == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Undraw();

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
                Draw();
            }
        }

        public bool IsFinished()
        {
            return IsCollidingWith(endPoint);
        }
    }
}
