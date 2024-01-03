using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class VictoryView : MonoBehaviour, EventObserver
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _backToMenutButton;

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _backToMenutButton.onClick.AddListener(BackToMenu);
        }

        private void Start()
        {
            gameObject.SetActive(false);
            ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.Victory, this);
        }
        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<IEventQueue>().UnSubscribe(EventIds.Victory, this);
        }

        private void RestartGame()
        {
            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new StartBattleCommand());
            gameObject.SetActive(false);
        }

        private void BackToMenu()
        {
            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new LoadSceneCommand("Menu"));
        }

        public void Process(EventData eventData)
        {

            if (eventData.EventId == EventIds.Victory)
            {
                _scoreText.SetText(ScoreView.Instance.CurrentScore.ToString());
                gameObject.SetActive(true);
            }
        }
    }
}