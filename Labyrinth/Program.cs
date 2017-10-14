using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Labyrinth
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;

            Labyrinth grid = new Labyrinth(20, 12);

            Stopwatch stopwatch = new Stopwatch();

            do
            {
                grid.Draw();
                Thread.Sleep(0);
            } while (!grid.IsCompleted());

            grid.DrawWalls();

            Player player = new Player('@');

            stopwatch.Start();
            do
            {
                player.Update();
            } while (!player.IsFinished());
            stopwatch.Stop();

            TimeSpan time = stopwatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}.{2:00}", time.Minutes, time.Seconds, time.Milliseconds / 10);

            Console.SetCursorPosition(Console.WindowWidth / 2 + 2, Console.WindowTop);
            Console.Write("Вы прошли лабиринт за {0}!", elapsedTime);
            Console.SetCursorPosition(Console.WindowWidth / 2 + 2, Console.WindowTop + 1);
        }
    }
}