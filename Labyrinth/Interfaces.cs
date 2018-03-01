using System;

namespace Labyrinth
{
    // Menu and start of the game
    public interface IMainUserInterface
    {
        void StartGame(IGameLoop gameLoop, IGame game);
    }

    // Game process
    public interface IGameLoop
    {
        void Run(IGame game);
    }

    // This interface should be implemented by game object
    public interface IGame
    {
        void Initialize();
        void DisplayField();
        void DisplayPlayer();
        void HandleKey(ConsoleKeyInfo cki);
        bool IsWon();
    }
}
