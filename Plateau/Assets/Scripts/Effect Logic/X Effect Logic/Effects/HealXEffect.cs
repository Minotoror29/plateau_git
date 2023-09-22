using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealXEffect : XEffect
{
    public HealXEffect(TableManager tableManager, string description, string description2, int amount) : base(tableManager, description, description2, amount)
    {
    }

    public override void Activate()
    {
        TableManager.Player.Heal(Amount);
        ResolveEffect();
    }
}
