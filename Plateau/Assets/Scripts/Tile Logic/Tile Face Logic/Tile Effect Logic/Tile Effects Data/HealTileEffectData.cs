using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Effect/Heal")]
public class HealTileEffectData : TileEffectData
{
    public int healthAmount;

    public override void Activate(TableManager tableManager, Player player)
    {
        player.Heal(healthAmount);
    }
}
