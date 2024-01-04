using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using Ships.Enemies;
using System;
using System.Threading.Tasks;

internal class StopBattleCommand : ICommand
{
    public Task Execute()
    {
        var serviceLocator = ServiceLocator.Instance;
        serviceLocator.GetService<EnemySpawner>().StopAndReset();
        return Task.CompletedTask;
    }
}