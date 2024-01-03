using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using Ships;
using Ships.Enemies;
using System.Threading.Tasks;
using UI;

public class StartBattleCommand : ICommand
{
    public async Task Execute()
    {
        await new ShowScreenFadeCommand().Execute();

        var serviceLocator = ServiceLocator.Instance;
        serviceLocator.GetService<GameStateController>().Reset();
        serviceLocator.GetService<ScoreView>().Reset();
        serviceLocator.GetService<EnemySpawner>().StartSpawn();
        serviceLocator.GetService<ShipInstaller>().SpawnUserShip();

        await new HideScreenFadeCommand().Execute();
    }
}
