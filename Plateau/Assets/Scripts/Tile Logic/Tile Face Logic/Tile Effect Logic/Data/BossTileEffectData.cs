using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Effect/Boss")]
public class BossTileEffectData : TileEffectData
{
    public override TileEffect Effect(TableManager tableManager, TileState state)
    {
        return new BossTileEffect(tableManager, state);
    }
}
