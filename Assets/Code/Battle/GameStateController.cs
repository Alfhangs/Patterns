using Battle;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class GameStateController : MonoBehaviour
{

    public enum GameStates
    {
        Playing,
        GameOver,
        Victory
    }

    private int aliveShip;
    private bool allShipSpawned;

    [SerializeField] private GameFacade gameFacade;
    private IGameState currentState;

    private Dictionary<GameStates, IGameState> idToState;

    private void Awake()
    {
        idToState = new Dictionary<GameStates, IGameState>
        {
            {GameStates.Playing, new PlayingState() },
            {GameStates.GameOver, new GameOverState(gameFacade) },
            {GameStates.Victory, new VictoryState(gameFacade) }
        };
    }
    private void Start()
    {
        currentState = GetState(GameStates.Playing);
        currentState.Start(ChangeNextState);
    }

    private async void ChangeNextState(GameStates NextState)
    {
        await Task.Yield(); //Con esto, le decimos que espere un frame
        currentState.Stop();
        currentState = GetState(NextState);
        currentState.Start(ChangeNextState);
    }

    public void Reset()
    {
       ChangeNextState(GameStates.Playing);
    }

    private IGameState GetState(GameStates state)
    {
        return idToState[state];
    }
}