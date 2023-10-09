using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbility : Ability
{
    public BossAbility(TableManager tableManager, TileState state, string description) : base(tableManager, state, description)
    {
    }

    public override void Activate()
    {
        TableManager.Boss.TakeDamage(TableManager.TossDice());

        if (TableManager.Boss.Health > 0)
        {
            TableManager.Player.TakeDamage(TableManager.TossDice());
        }

        ResolveAbility();
    }
}
