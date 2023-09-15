using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTileEffect : TileEffect
{
    public BossTileEffect(TableManager tableManager) : base(tableManager)
    {
    }

    public override void Activate(Player player)
    {
        TableManager.Boss.TakeDamage(TableManager.TossDice());

        if (TableManager.Boss.Health > 0)
        {
            player.TakeDamage(TableManager.TossDice());
        }

        Resolve();
    }
}
