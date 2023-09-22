using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealXEffect : XEffect
{
    public HealXEffect(TableManager tableManager, string description, string unit, int amount) : base(tableManager, description, unit, amount)
    {
    }

    public override void Activate()
    {
        TableManager.Player.Heal(Amount);
        ResolveEffect();
    }
}
