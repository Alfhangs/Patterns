using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RestartBattleCommand : ICommand
{
    public async Task Execute()
    {
        ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(new EventData(EventIds.Restart));
        await new StopBattleCommand().Execute();
        await new StartBattleCommand().Execute();
    }

}
