using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UI;
using UnityEngine;

public class ShowScreenFadeCommand : ICommand
{
    public async Task Execute()
    {
        var serviceLocator = ServiceLocator.Instance;
        serviceLocator.GetService<ScreenFade>().Show();
        await Task.Delay(500);
    }
}
