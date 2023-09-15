using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawArtifactTileEffect : TileEffect
{
    private int _artifactAmount;

    public DrawArtifactTileEffect(TableManager tableManager, DrawArtifactTileEffectData data) : base(tableManager)
    {
        _artifactAmount = data.artifactAmount;
    }

    public override void Activate(Player player)
    {
        player.DrawArtifact(_artifactAmount);
    }
}
