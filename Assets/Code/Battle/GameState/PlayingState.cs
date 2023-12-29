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

            EventQueue.Instance.Subscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.Subscribe(EventIds.ShipSpawned, this);
            EventQueue.Instance.Subscribe(EventIds.AllShipSpawned, this);
        }

        public void Stop()
        {
            EventQueue.Instance.UnSubscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.UnSubscribe(EventIds.ShipSpawned, this);
            EventQueue.Instance.UnSubscribe(EventIds.AllShipSpawned, this);
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
