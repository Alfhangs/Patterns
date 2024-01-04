using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using System;

namespace Battle
{
    public class VictoryState : IGameState
    {
        private readonly ICommand _stopBattleCommand;

        public VictoryState(ICommand stopBattleCommand)
        {
            _stopBattleCommand = stopBattleCommand;
        }

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(_stopBattleCommand);
            ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(new EventData(EventIds.Victory));
        }

        public void Stop()
        {
        }
    }
}