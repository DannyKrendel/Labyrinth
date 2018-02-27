using System;

namespace Labyrinth
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;

            IMainUserInterface userInterface = new MainUserInterface();
            IGameLoop gameLoop = new GameLoop();
            IGame game = new Game(21, 35, '@', 10);

            userInterface.StartGame(gameLoop, game);
        }
    }
}