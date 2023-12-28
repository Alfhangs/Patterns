using Battle;
using Ships.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour, EventObserver
{

    private enum GameStates
    {
        Playing,
        GameOver,
        Victory
    }

    private int aliveShip;
    private bool allShipSpawned;

    [SerializeField] private GameFacade gameFacade;
    private GameStates currentState;

    private void Start()
    {
        EventQueue.Instance.Subscribe(EventIds.ShipDestroyed, this);
        EventQueue.Instance.Subscribe(EventIds.ShipSpawned, this);
        EventQueue.Instance.Subscribe(EventIds.AllShipSpawned, this);
    }

    private void OnDestroy()
    {
        EventQueue.Instance.UnSubscribe(EventIds.ShipDestroyed, this);
        EventQueue.Instance.UnSubscribe(EventIds.ShipSpawned, this);
        EventQueue.Instance.UnSubscribe(EventIds.AllShipSpawned, this);
    }

    public void Reset()
    {
        aliveShip = 0;
        allShipSpawned = false;
        currentState = GameStates.Playing;
    }

    public void Process(EventData eventData)
    {
        if(currentState != GameStates.Playing)
        {
            return;
        }

        if (eventData.EventId == EventIds.ShipDestroyed)
        {
            aliveShip -= 1;
            var shipDestroyEventData = (ShipDestroyedEventData)eventData;
            if (shipDestroyEventData.Team == Teams.Ally)
            {
                currentState = GameStates.GameOver;
                gameFacade.StopBattle();
                EventQueue.Instance.EnqueueEvent(new EventData(EventIds.GameOver));
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
        if(aliveShip == 0 && allShipSpawned == true)
        {
            //VICTORY
            currentState = GameStates.Victory;
            Debug.Log("Victory");
            gameFacade.StopBattle();
            EventQueue.Instance.EnqueueEvent(new EventData(EventIds.Victory));
        }
    }
}