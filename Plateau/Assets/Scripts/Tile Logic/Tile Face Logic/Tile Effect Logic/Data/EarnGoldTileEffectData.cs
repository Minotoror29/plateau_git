using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Effect/Earn Gold")]
public class EarnGoldTileEffectData : TileEffectData
{
    public int goldAmount;

    public override TileEffect Effect(TableManager tableManager)
    {
        return new EarnGoldTileEffect(tableManager, this);
    }
}
