using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat Reward/Gold")]
public class GoldCombatRewardData : CombatRewardData
{
    public ValueApplicationData amount;

    public override CombatReward Reward(TableManager tableManager, CombatTileEffect combat)
    {
        return new GoldCombatReward(tableManager, combat, amount);
    }
}
