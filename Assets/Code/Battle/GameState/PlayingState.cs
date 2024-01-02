using Patterns.Decoupling.ServiceLocator;
using Ships.Common;
using System;

namespace Battle
{
    public class PlayingState : IGameState, EventObserver
    {
        private int aliveShip;
        private bool allShipSpawned;
        private Action<GameStateController.GameStates> thisOnEndedCallback;


        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            thisOnEndedCallback = onEndedCallback;
            aliveShip = 0;
            allShipSpawned = false;

            ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.ShipDestroyed, this);
            ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.ShipSpawned, this);
            ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.AllShipSpawned, this);
        }

        public void Stop()
        {
            ServiceLocator.Instance.GetService<IEventQueue>().UnSubscribe(EventIds.ShipDestroyed, this);
            ServiceLocator.Instance.GetService<IEventQueue>().UnSubscribe(EventIds.ShipSpawned, this);
            ServiceLocator.Instance.GetService<IEventQueue>().UnSubscribe(EventIds.AllShipSpawned, this);
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ShipDestroyed)
            {
                aliveShip -= 1;
                var shipDestroyEventData = (ShipDestroyedEventData)eventData;
                if (shipDestroyEventData.Team == Teams.Ally)
                {
                    thisOnEndedCallback?.Invoke(GameStateController.GameStates.GameOver);
                    return;
                }
            }
            else if (eventData.EventId == EventIds.ShipSpawned)
            {
                aliveShip += 1;
            }
            else if (eventData.EventId == EventIds.AllShipSpawned)
            {
                allShipSpawned = true;
            }
            CheckGameState();
        }

        private void CheckGameState()
        {
            if (aliveShip == 0 && allShipSpawned == true)
            {
                //VICTORY
                thisOnEndedCallback?.Invoke(GameStateController.GameStates.Victory);
            }
        }
    }
}
