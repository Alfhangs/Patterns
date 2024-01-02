using Patterns.Decoupling.ServiceLocator;
using System;

namespace Battle
{
    public class VictoryState : IGameState
    {
        private readonly IGameFacade _igameFacade;

        public VictoryState(IGameFacade igameFacade)
        {
            _igameFacade = igameFacade;
        }

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            _igameFacade.StopBattle();
            ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(new EventData(EventIds.Victory));
        }

        public void Stop()
        {
        }
    }
}