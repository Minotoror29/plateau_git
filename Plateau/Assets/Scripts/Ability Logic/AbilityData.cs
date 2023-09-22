using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityData : ScriptableObject
{
    public abstract Ability Ability(TableManager tableManager, TileState state);
}
