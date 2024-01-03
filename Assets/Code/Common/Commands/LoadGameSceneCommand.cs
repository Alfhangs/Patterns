using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns.Behaviour.Command;
using System.Threading.Tasks;

public class LoadGameSceneCommand : ICommand
{
    public async Task Execute()
    {
        await new LoadSceneCommand("GamePlay").Execute();
        await new StartBattleCommand().Execute();
    }
}
