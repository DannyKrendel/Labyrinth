namespace Labyrinth
{
    public interface IMainUserInterface
    {
        void StartGame(IGameLoop gameLoop, IGame game);
    }

    public interface IGameLoop
    {
        void Run(IGame game);
    }

    public interface IGame
    {
        bool Update();
    }
}
