using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Effect/Flip")]
public class FlipTileEffectData : TileEffectData
{
    public override TileEffect Effect(TableManager tableManager, TileState state)
    {
        return new FlipTileEffect(tableManager, state);
    }
}
