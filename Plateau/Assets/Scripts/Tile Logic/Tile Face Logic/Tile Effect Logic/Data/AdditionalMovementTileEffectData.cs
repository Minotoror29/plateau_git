using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Effect/Additional Movement")]
public class AdditionalMovementTileEffectData : TileEffectData
{
    public override TileEffect Effect(TableManager tableManager)
    {
        return new AdditionalMovementTileEffect(tableManager);
    }
}