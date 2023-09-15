using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Effect/Boss")]
public class BossTileEffectData : TileEffectData
{
    public override TileEffect Effect(TableManager tableManager)
    {
        return new BossTileEffect(tableManager);
    }
}
