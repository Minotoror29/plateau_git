using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealXEffect : XEffect
{
    public HealXEffect(TableManager tableManager, TileState state, string description, string unit, int amount) : base(tableManager, state, description, unit, amount)
    {
    }

    public override void Activate()
    {
        TableManager.Player.Heal(Amount);
        ResolveEffect();
    }
}
