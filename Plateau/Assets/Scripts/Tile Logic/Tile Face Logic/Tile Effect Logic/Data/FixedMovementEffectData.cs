using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Effect/Fixed Movement")]
public class FixedMovementEffectData : TileEffectData
{
    public int movementValue;

    public override TileEffect Effect(TableManager tableManager)
    {
        return new FixedMovementEffect(tableManager, movementValue);
    }
}
