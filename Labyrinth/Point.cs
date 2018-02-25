using System;

namespace Labyrinth
{
    class Point : Color
    {
        public char value;
        public int x;
        public int y;

        public Point() { }

        public Point(char value, int x, int y)
        {
            this.value = value;
            this.x = x;
            this.y = y;
        }

        public void Display(ConsoleColor fgColor, ConsoleColor bgColor)
        {
            Console.SetCursorPosition(x, y);
            ColorDisplay(value.ToString(), fgColor, bgColor);
        }

        public void Erase(ConsoleColor fgColor, ConsoleColor bgColor)
        {
            Console.SetCursorPosition(x, y);
            ColorDisplay(" ", fgColor, bgColor);
        }

        public bool IsCollidingWith(Point p)
        {
            return x == p.x && y == p.y;
        }

        // Перегрузка операторов
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.value, p1.x + p2.x, p1.y + p2.y);
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.value, p1.x - p2.x, p1.y - p2.y);
        }

        public override string ToString()
        {
            return value + ", " + x + ", " + y + ", ";
        }
    }
}