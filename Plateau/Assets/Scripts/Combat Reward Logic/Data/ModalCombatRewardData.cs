using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat Reward/Modal")]
public class ModalCombatRewardData : CombatRewardData
{
    public int goldAmount;
    public int artifactAmount;

    public override void EarnReward(Player player, CombatTileEffect effect)
    {
        player.TableManager.ModalCombatRewardDisplay.gameObject.SetActive(true);
        player.TableManager.ModalCombatRewardDisplay.SetRewards(player, effect, goldAmount, artifactAmount);
    }
}
