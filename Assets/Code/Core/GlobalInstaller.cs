using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using System.Threading.Tasks;
using UI;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalInstaller : GeneralInstaller
{

    protected override void DoStart()
    {
        ServiceLocator.Instance.GetService<CommandQueue>().AddCommand( new LoadSceneCommand("Menu"));
    }
    protected override void DoInstallDependencies()
    {
        ServiceLocator.Instance.RegisterService(CommandQueue.Instance);
    }
}