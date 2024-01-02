using Patterns.Decoupling.ServiceLocator;
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

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame);
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
            ServiceLocator.Instance.GetService<IGameFacade>().StartBattle();
            gameObject.SetActive(false);
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