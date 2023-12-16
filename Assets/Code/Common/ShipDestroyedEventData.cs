using Ships.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDestroyedEventData : EventData
{
    private readonly int _scoreToAdd;
    private readonly Teams _team;
    private readonly int _instanceId;

    public int ScoreToAdd => _scoreToAdd;

    public Teams Team => _team;

    public int InstanceId => _instanceId;

    public ShipDestroyedEventData(int scoreToAdd, Teams team, int instanceId) : base(EventIds.ShipDestroyed)
    {
        _scoreToAdd = scoreToAdd;
        _team = team;
        _instanceId = instanceId;
    }
}
