using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityData : ScriptableObject
{
    [TextArea(3, 10)] public string description;

    public abstract Ability Ability(TableManager tableManager, TileState state);
}
