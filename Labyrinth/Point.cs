using System;

namespace Labyrinth
{
    abstract class Point : Color
    {
        // Point value and coordinates
        public virtual char Value { get; set; }
        public virtual int X { get; set; }
        public virtual int Y { get; set; }

        // Constructors
        public Point() { }

        public Point(char value, int x, int y)
        {
            Value = value;
            X = x;
            Y = y;
        }

        // Display point with certain colors
        public virtual void Display(ConsoleColor fgColor, ConsoleColor bgColor)
        {
            Console.SetCursorPosition(Y, X);
            ColorDisplay(Value.ToString(), fgColor, bgColor);
        }

        // Erase point with certain colors
        public virtual void Erase(ConsoleColor fgColor, ConsoleColor bgColor)
        {
            Console.SetCursorPosition(Y, X);
            ColorDisplay(" ", fgColor, bgColor);
        }

        // Is point colliding with another point
        public virtual bool IsCollidingWith(Point p)
        {
            return X == p.X && Y == p.Y;
        }

        #region overloading section

        public override string ToString()
        {
            return $"\"{Value}\", {X}, {Y}";
        }

        #endregion
    }
}