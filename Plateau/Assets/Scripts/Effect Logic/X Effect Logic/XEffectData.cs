using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class XEffectData : ScriptableObject
{
    public string description;
    public string unit;

    public abstract XEffect Effect(TableManager tableManager, TileState state, int amount);
}
