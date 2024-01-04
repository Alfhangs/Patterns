using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuView : MonoBehaviour
{
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _backToMenuButton;
    private IInGameMenuMediator _mediator;

    private void Awake()
    {
        _resumeButton.onClick.AddListener(OnResumePressed);
        _restartButton.onClick.AddListener(OnRestartPressed);
        _backToMenuButton.onClick.AddListener(OnBackToMenuPressed);
    }

    internal void Configure(IInGameMenuMediator mediator)
    {
        _mediator = mediator;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnRestartPressed()
    {
        _mediator.OnRestartPressed();
    }

    private void OnBackToMenuPressed()
    {
        _mediator.OnBackToMenuPressed();
    }

    private void OnResumePressed()
    {
        _mediator.OnResumePressed();
    }
}
