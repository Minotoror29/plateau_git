using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Effect/Pay to Flip")]
public class PayToFlipTileEffectData : TileEffectData
{
    public int goldAmount;

    public override TileEffect Effect(TableManager tableManager, TileState state)
    {
        return new PayToFlipTileEffect(tableManager, state, goldAmount);
    }
}
