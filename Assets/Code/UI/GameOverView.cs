using Battle;
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
        [SerializeField] private GameFacade gameFacade;

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame);
        }
        private void Start()
        {
            gameObject.SetActive(false);
            EventQueue.Instance.Subscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.Subscribe(EventIds.GameOver, this);
        }
        private void OnDestroy()
        {
            EventQueue.Instance.UnSubscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.UnSubscribe(EventIds.GameOver, this);
        }

        private void RestartGame()
        {
            gameFacade.StartBattle();
            gameObject.SetActive(false);
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ShipDestroyed)
            {
                var shipDestroyEventData = (ShipDestroyedEventData)eventData;
                if (shipDestroyEventData.Team == Teams.Ally)
                {
                    gameFacade.StopBattle();
                    EventQueue.Instance.EnqueueEvent(new EventData(EventIds.GameOver));
                }
                return;
            }
            if (eventData.EventId == EventIds.GameOver)
            {
                _scoreText.SetText(ScoreView.Instance.CurrentScore.ToString());
                gameObject.SetActive(true);
            }
        }
    }
}
