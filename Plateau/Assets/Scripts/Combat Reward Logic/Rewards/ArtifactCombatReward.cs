using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactCombatReward : CombatReward
{
    private int _amount;

    public ArtifactCombatReward(TableManager tableManager, CombatEffect combat, int amount) : base(tableManager, combat)
    {
        _amount = amount;
    }

    public override void DetermineReward()
    {
        Resolve();
    }

    public override void EarnReward(Player player)
    {
        player.DrawArtifacts(_amount);
    }
}
