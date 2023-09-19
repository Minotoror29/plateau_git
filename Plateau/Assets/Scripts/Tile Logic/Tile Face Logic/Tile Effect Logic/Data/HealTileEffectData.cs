using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Effect/Heal")]
public class HealTileEffectData : TileEffectData
{
    public int healthAmount;

    public override TileEffect Effect(TableManager tableManager, TileState state)
    {
        return new HealTileEffect(tableManager, state, this);
    }
}
