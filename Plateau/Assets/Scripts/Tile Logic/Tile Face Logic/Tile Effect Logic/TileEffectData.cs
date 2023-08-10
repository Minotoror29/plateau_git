using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileEffectData : ScriptableObject
{
    public abstract void Activate(TableManager tableManager, Player player);
}
