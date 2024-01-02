using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Patterns.Decoupling.ServiceLocator;

public class LoaderScreenInstaller : Installer
{
    [SerializeField] private LoadingScreen _loadingScreen;

    public override void Install(ServiceLocator serviceLocator)
    {
        DontDestroyOnLoad(_loadingScreen.gameObject);
        serviceLocator.RegisterService(_loadingScreen);
    }

}
