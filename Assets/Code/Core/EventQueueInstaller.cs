using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  EventQueueInstaller : Installer
{
    [SerializeField] private EventQueueImp _eventQueue;

    public override void Install(Patterns.Decoupling.ServiceLocator.ServiceLocator serviceLocator)
    {
        DontDestroyOnLoad(_eventQueue.gameObject);
        serviceLocator.RegisterService<IEventQueue>(_eventQueue);
    }
}
