using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        void DisplayField();
        void DisplayCell();
        void MakeMove(ConsoleKeyInfo cki);
        bool IsWon();
    }
}
