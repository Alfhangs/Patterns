using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle
{
    public interface IGameState
    {
        void Start(Action<GameStateController.GameStates> onEndedCallback);
        void Stop();
    }
}
