using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat Reward/Gold")]
public class GoldCombatRewardData : CombatRewardData
{
    public int amount;

    public override void EarnReward(Player player, TileEffect effect)
    {
        player.EarnGold(amount);

        effect.Resolve();
    }
}
