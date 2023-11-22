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
        public static GameOverView Instance { get; private set; }
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private GameFacade gameFacade;
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            _restartButton.onClick.AddListener(RestartGame);
            gameObject.SetActive(false);

            EventQueue.Instance.Subscribe(EventIds.ShipDestroyed, this);
        }

        private void RestartGame()
        {
            gameFacade.StartBattle();
            gameObject.SetActive(false);
        }

        private void Show()
        {
            gameFacade.StopBattle();
            _scoreText.SetText(ScoreView.Instance.CurrentScore.ToString());
            gameObject.SetActive(true);
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId != EventIds.ShipDestroyed)
            {
                return;
            }

            var shipDestroyEventData = (ShipDestroyedEventData)eventData;
            if (shipDestroyEventData.Teams == Teams.Ally)
            {
                Show();
            }
        }
    }
}
