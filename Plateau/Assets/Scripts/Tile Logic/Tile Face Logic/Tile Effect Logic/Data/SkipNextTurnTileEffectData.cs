using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Effect/Skip Next Turn")]
public class SkipNextTurnTileEffectData : TileEffectData
{
    public override TileEffect Effect(TableManager tableManager, TileState state)
    {
        return new SkipNextTurnTileEffect(tableManager, state);
    }
}
