using Patterns.Decoupling.ServiceLocator;
using System.Threading.Tasks;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalInstaller : GeneralInstaller
{

    protected override async void DoStart()
    {
        new LoadSceneCommand("Menu").Execute();
    }
    protected override void DoInstallDependencies()
    {
    }
}