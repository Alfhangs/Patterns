using Battle;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using Ships.Common;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _backToMenuButton;
        private IInGameMenuMediator _mediator;

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _backToMenuButton.onClick.AddListener(BackToMenu);
        }

        internal void Configure(IInGameMenuMediator mediator)
        {
            _mediator = mediator;
        }

        private void RestartGame()
        {
            _mediator.OnRestartPressed();
        }

        private void BackToMenu()
        {
            _mediator.OnBackToMenuPressed();
        }

        internal void Hide()
        {
            gameObject.SetActive(false);
        }

        internal void Show()
        {
            _scoreText.SetText(ScoreView.Instance.CurrentScore.ToString());
            gameObject.SetActive(true);
        }
    }
}