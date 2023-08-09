using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileEffectData : ScriptableObject
{
    public string description;

    public abstract void Activate(Player player);
}
