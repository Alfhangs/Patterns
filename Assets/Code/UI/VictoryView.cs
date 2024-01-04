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
    public class VictoryView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _backToMenutButton;
        private IInGameMenuMediator _mediator;

        private void Awake()
        {
            _restartButton.onClick.AddListener(OnRestartPressed);
            _backToMenutButton.onClick.AddListener(OnBackToMenuPressed);
        }

        internal void Configure(IInGameMenuMediator mediator)
        {
            _mediator = mediator;
        }

        private void OnRestartPressed()
        {
            _mediator.OnRestartPressed();
        }

        private void OnBackToMenuPressed()
        {
            _mediator.OnBackToMenuPressed();
        }

        internal void Show()
        {
            _scoreText.SetText(ScoreView.Instance.CurrentScore.ToString());
            gameObject.SetActive(true);
        }

        internal void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}