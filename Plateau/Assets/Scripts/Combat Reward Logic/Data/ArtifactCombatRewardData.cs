using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat Reward/Artifact")]
public class ArtifactCombatRewardData : CombatRewardData
{
    public int amount;

    public override CombatReward Reward(TableManager tableManager, CombatAbility combat)
    {
        return new ArtifactCombatReward(tableManager, combat, amount);
    }
}
