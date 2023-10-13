using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResourceData : ScriptableObject
{
    public abstract void LoseResource(Player player, int amount);
    public abstract int PlayerResource(Player player);
}
