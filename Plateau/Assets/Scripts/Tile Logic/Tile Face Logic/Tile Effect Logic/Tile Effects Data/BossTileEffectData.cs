using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Effect/Boss")]
public class BossTileEffectData : TileEffectData
{
    public override void Activate(TableManager tableManager, Player player)
    {
        tableManager.Boss.TakeDamage(tableManager.TossDice());

        if (tableManager.Boss.Health > 0)
        {
            player.TakeDamage(tableManager.TossDice());
        }
    }
}
