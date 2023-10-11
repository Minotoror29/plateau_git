using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnXGold : XEffect
{
    public EarnXGold(TableManager tableManager, TileState state, string description, string unit, int amount) : base(tableManager, state, description, unit, amount)
    {
    }

    public override void Activate()
    {
        TableManager.CurrentPlayer.EarnGold(Amount);
        ResolveEffect();
    }
}
