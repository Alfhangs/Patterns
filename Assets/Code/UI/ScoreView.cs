using Ships.Common;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreView : MonoBehaviour, EventObserver
    {
        public static ScoreView Instance { get; private set; }

        [SerializeField] private TextMeshProUGUI _text;

        private int _currentScore;
        public int CurrentScore
        {
            get => _currentScore;
            private set
            {
                _currentScore = value;
                _text.SetText(_currentScore.ToString());
            }
        }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            EventQueue.Instance.Subscribe(EventIds.ShipDestroyed, this);
        }

        private void OnDestroy()
        {
            EventQueue.Instance.UnSubscribe(EventIds.ShipDestroyed, this);
        }

        public void Reset()
        {
            CurrentScore = 0;
        }

        private void AddScore(Teams killedTeam, int scoreToAdd)
        {
            if (killedTeam != Teams.Enemy)
            {
                return;
            }

            CurrentScore += scoreToAdd;
            _text.SetText(CurrentScore.ToString());
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId != EventIds.ShipDestroyed)
            {
                return;
            }

            var shipDestroyEventData = (ShipDestroyedEventData)eventData;
            AddScore(shipDestroyEventData.Team, shipDestroyEventData.ScoreToAdd);
        }
    }
}
