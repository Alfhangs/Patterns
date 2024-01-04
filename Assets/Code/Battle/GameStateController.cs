using Battle;
using Patterns.Decoupling.ServiceLocator;
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

    private IGameState currentState;

    private Dictionary<GameStates, IGameState> idToState;

    private void Start()
    {
        var stopBattleCommand = new StopBattleCommand();
        idToState = new Dictionary<GameStates, IGameState>
        {
            {GameStates.Playing, new PlayingState() },
            {GameStates.GameOver, new GameOverState(stopBattleCommand) },
            {GameStates.Victory, new VictoryState(stopBattleCommand) }
        };
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