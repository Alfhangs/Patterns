using Battle;
using Patterns.Decoupling.ServiceLocator;
using Ships.Common;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameOverView : MonoBehaviour, EventObserver
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame);
        }
        private void Start()
        {
            gameObject.SetActive(false);
            ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.GameOver, this);
        }
        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<IEventQueue>().UnSubscribe(EventIds.GameOver, this);
        }

        private void RestartGame()
        {
            //ServiceLocator.Instance.GetService<IGameFacade>().StartBattle();
            gameObject.SetActive(false);
        }

        public void Process(EventData eventData)
        {
            
            if (eventData.EventId == EventIds.GameOver)
            {
                _scoreText.SetText(ScoreView.Instance.CurrentScore.ToString());
                gameObject.SetActive(true);
            }
        }
    }
}