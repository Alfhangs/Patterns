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

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame);
        }
        private void Start()
        {
            gameObject.SetActive(false);
            EventQueue.Instance.Subscribe(EventIds.GameOver, this);
        }
        private void OnDestroy()
        {
            EventQueue.Instance.UnSubscribe(EventIds.GameOver, this);
        }

        private void RestartGame()
        {
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
