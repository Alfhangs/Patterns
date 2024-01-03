using Patterns.Creation.Factory;
using Patterns.Decoupling.ServiceLocator;
using Ships;
using UI;
using UnityEngine;

public class GameInstaller : GeneralInstaller
{
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private ShipInstaller _shipInstaller;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private GameStateController _gameStateController;
    [SerializeField] private ScreenFade _screenFade;

    protected override void DoStart()
    {
    }

    protected override void DoInstallDependencies()
    {
        ServiceLocator.Instance.RegisterService(_scoreView);
        ServiceLocator.Instance.RegisterService(_shipInstaller);
        ServiceLocator.Instance.RegisterService(_enemySpawner);
        ServiceLocator.Instance.RegisterService(_gameStateController);
        ServiceLocator.Instance.RegisterService(_screenFade);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.UnregisterService<ScoreView>();
        ServiceLocator.Instance.UnregisterService<ShipInstaller>();
        ServiceLocator.Instance.UnregisterService<EnemySpawner>();
        ServiceLocator.Instance.UnregisterService<GameStateController>();
        ServiceLocator.Instance.UnregisterService<ScreenFade>();
    }
}