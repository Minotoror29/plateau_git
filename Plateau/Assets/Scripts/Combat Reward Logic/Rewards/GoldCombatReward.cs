using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCombatReward : CombatReward
{
    private ValueApplication _amount;

    public GoldCombatReward(TableManager tableManager, CombatEffect combat, ValueApplicationData valueApplicationData) : base (tableManager, combat)
    {
        _amount = valueApplicationData.Value(tableManager);
    }

    public override void DetermineReward()
    {
        _amount.OnResolution += Resolve;
        _amount.DetermineValue();
    }

    public override void EarnReward(Player player)
    {
        _amount.OnResolution -= Resolve;
        player.EarnGold(_amount.Value);
    }
}
