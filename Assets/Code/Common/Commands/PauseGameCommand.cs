using Patterns.Behaviour.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class PauseGameCommand : ICommand
{
    public Task Execute()
    {
        Time.timeScale = 0;
        return Task.CompletedTask;
    }
}

