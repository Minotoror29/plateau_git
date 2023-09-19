using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat Reward/Gold")]
public class GoldCombatRewardData : CombatRewardData
{
    public ValueApplicationData amount;

    public override void EarnReward(Player player, CombatTileEffect effect)
    {
        player.EarnGold(amount.Value(player.TableManager));

        effect.ResolveReward(player);
    }
}
