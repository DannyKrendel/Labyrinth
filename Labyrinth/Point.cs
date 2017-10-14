using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Labyrinth
{
    class Point
    {
        public int x;
        public int y;
        public char ch;

        public Point()
        {

        }

        public Point(int x, int y, char ch)
        {
            this.x = x;
            this.y = y;
            this.ch = ch;
        }

        public virtual void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
        }

        public virtual void Undraw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        public virtual bool IsCollidingWith(Point p)
        {
            return p.x == x && p.y == y;
        }

        // Перегрузка операторов
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.x + p2.x, p1.y + p2.y, p1.ch);
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.x - p2.x, p1.y - p2.y, p1.ch);
        }

        public override string ToString()
        {
            return x + ", " + y + ", " + ch;
        }
    }
}