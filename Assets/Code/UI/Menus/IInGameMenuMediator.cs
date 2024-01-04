using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInGameMenuMediator
{
    void OnBackToMenuPressed();
    void OnRestartPressed();
    void OnResumePressed();
}
