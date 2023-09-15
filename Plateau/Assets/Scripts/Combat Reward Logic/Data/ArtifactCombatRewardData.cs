using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat Reward/Artifact")]
public class ArtifactCombatRewardData : CombatRewardData
{
    public int amount;

    public override void EarnReward(Player player, TileEffect effect)
    {
        player.DrawArtifact(amount);

        effect.Resolve();
    }
}
