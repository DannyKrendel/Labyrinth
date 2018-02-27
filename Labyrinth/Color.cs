using System;

namespace Labyrinth
{
    abstract class Color
    {
        protected static void ColorDisplay(string str, ConsoleColor fgColor, ConsoleColor bgColor)
        {
            ConsoleColor defaultFg = Console.ForegroundColor;
            ConsoleColor defaultBg = Console.BackgroundColor;

            Console.ForegroundColor = fgColor;
            Console.BackgroundColor = bgColor;

            Console.Write(str);

            Console.ForegroundColor = defaultFg;
            Console.BackgroundColor = defaultBg;
        }
    }
}
