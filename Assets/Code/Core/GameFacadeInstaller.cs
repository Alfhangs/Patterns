using Battle;
using System.Collections;
using Patterns.Decoupling.ServiceLocator;
using UnityEngine;

public class GameFacadeInstaller : Installer
{
    [SerializeField] private GameFacade _gameFacade;
    public override void Install(ServiceLocator serviceLocator)
    {
        serviceLocator.RegisterService<IGameFacade>(_gameFacade);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.UnregisterService<IGameFacade>();
    }
}
