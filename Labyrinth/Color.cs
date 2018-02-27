using System;

namespace Labyrinth
{
    abstract class Color
    {
        // Any hereditary class can use this function to display string in color
        protected void ColorDisplay(string str, ConsoleColor fgColor, ConsoleColor bgColor)
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
