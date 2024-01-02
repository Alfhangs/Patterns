using Patterns.Decoupling.ServiceLocator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GeneralInstaller : MonoBehaviour
{
    [SerializeField] private Installer[] installers;

    private void Awake()
    {
        InstallDependencies();
    }

    private void Start()
    {
        DoStart();
    }

    protected abstract void DoStart();

    private void InstallDependencies()
    {
        foreach (var installer in installers)
        {
            installer.Install(ServiceLocator.Instance);
        }
        DoInstallDependencies();
    }
    protected abstract void DoInstallDependencies();
}
