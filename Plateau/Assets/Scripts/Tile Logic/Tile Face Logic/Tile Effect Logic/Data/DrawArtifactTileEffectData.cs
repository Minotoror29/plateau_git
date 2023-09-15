using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Effect/Draw Artifact")]
public class DrawArtifactTileEffectData : TileEffectData
{
    public int artifactAmount;

    public override TileEffect Effect(TableManager tableManager)
    {
        return new DrawArtifactTileEffect(tableManager, this);
    }
}
