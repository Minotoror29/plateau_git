using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnGoldEffect : Effect
{
    private int _goldAmount;

    public EarnGoldEffect(TableManager tableManager, string description, int goldAmount) : base(tableManager, description)
    {
        _goldAmount = goldAmount;
    }

    public override void Activate()
    {
        TableManager.Player.EarnGold(_goldAmount);

        ResolveEffect();
    }
}
