using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventQueue 
{
    public void Subscribe(EventIds eventId, EventObserver eventObserver);

    public void UnSubscribe(EventIds eventId, EventObserver eventObserver);
    public void EnqueueEvent(EventData eventData);
}
