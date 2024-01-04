using Battle;
using Patterns.Behaviour.Command;
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
        private readonly ICommand _stopBattleCommand;

        public GameOverState(ICommand stopCommand)
        {
            _stopBattleCommand = stopCommand;
        }

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(_stopBattleCommand);
            ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(new EventData(EventIds.GameOver));
        }

        public void Stop()
        {
        }
    }
}
