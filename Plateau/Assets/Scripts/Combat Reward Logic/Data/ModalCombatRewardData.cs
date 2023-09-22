using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat Reward/Modal")]
public class ModalCombatRewardData : CombatRewardData
{
    public int goldAmount;
    public int artifactAmount;

    public override CombatReward Reward(TableManager tableManager, CombatAbility combat)
    {
        return new ModalCombatReward(tableManager, combat, this);
    }
}
