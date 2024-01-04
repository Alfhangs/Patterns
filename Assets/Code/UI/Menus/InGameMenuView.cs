using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenuView : MonoBehaviour, IInGameMenuMediator, EventObserver
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private PauseMenuView _pauseMenuView;
    [SerializeField] private VictoryView _victoryView;
    [SerializeField] private GameOverView _gameOverView;

    private void Awake()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonPressed);
        _pauseMenuView.Configure(this);
        _victoryView.Configure(this);
        _gameOverView.Configure(this);
    }

    private void Start()
    {
        HideAllMenus();
        ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.Victory, this);
        ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.GameOver, this);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.GetService<IEventQueue>().UnSubscribe(EventIds.Victory, this);
        ServiceLocator.Instance.GetService<IEventQueue>().UnSubscribe(EventIds.GameOver, this);
    }

    private void HideAllMenus()
    {
        _pauseMenuView.Hide();
        _victoryView.Hide();
        _gameOverView.Hide();
    }
    private void OnPauseButtonPressed()
    {
        ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new PauseGameCommand());
        _pauseMenuView.Show();
    }
    public void OnBackToMenuPressed()
    {
        ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new LoadSceneCommand("Menu"));
        ResumeGame();
    }

    public void OnRestartPressed()
    {
        HideAllMenus();
        ResumeGame();
        ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new RestartBattleCommand());
    }

    public void OnResumePressed()
    {
        _pauseMenuView.Hide();
        ResumeGame();
    }

    private void ResumeGame()
    {
        ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new ResumeGameCommand());
    }

    public void Process(EventData eventData)
    {
        if (eventData.EventId == EventIds.Victory)
        {
            _victoryView.Show();
            return;
        }

        if(eventData.EventId == EventIds.GameOver)
        {
            _gameOverView.Show();
            return;
        }
    }
}
