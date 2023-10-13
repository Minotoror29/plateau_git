using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeXDamageEffect : XEffect
{
    public TakeXDamageEffect(TableManager tableManager, TileState state, string description, string unit, int amount) : base(tableManager, state, description, unit, amount)
    {
    }

    public override void Activate()
    {
        TableManager.CurrentPlayer.TakeDamage(Amount);
        ResolveEffect();
    }
}
