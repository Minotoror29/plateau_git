using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnXGold : XEffect
{
    public EarnXGold(TableManager tableManager, string description, string unit, int amount) : base(tableManager, description, unit, amount)
    {
    }

    public override void Activate()
    {
        TableManager.Player.EarnGold(Amount);
        ResolveEffect();
    }
}
