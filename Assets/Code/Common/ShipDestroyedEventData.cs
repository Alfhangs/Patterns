using Ships.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDestroyedEventData : EventData
{
    private readonly int score;
    private readonly Teams teams;

    public int Score => score;

    public Teams Teams => teams;
    public ShipDestroyedEventData(int scoreToAdd, Teams team) : base(EventIds.ShipDestroyed)
    {
        score = scoreToAdd;
        teams = team;
    }



}
