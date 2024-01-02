using Battle;
using Patterns.Decoupling.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle
{
    internal class GameOverState : IGameState
    {
        private readonly IGameFacade _igameFacade;

        public GameOverState(IGameFacade igameFacade)
        {
            _igameFacade = igameFacade;
        }

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            _igameFacade.StopBattle();
            ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(new EventData(EventIds.GameOver));
        }

        public void Stop()
        {
        }
    }
}
