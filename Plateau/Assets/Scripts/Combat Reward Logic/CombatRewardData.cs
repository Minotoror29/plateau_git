using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatRewardData : ScriptableObject
{
    public abstract CombatReward Reward(TableManager tableManager, CombatEffect combat);
}
