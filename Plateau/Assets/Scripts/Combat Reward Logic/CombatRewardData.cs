using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatRewardData : ScriptableObject
{
    public abstract void EarnReward(Player player, TileEffect effect);
}
