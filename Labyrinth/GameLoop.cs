namespace Labyrinth
{
    class GameLoop : IGameLoop
    {
        public void Run(IGame game)
        {
            while (game.Update()) ;
        }
    }
}
