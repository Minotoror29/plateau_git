using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawArtifactTileEffect : TileEffect
{
    private int _artifactAmount;

    public DrawArtifactTileEffect(TableManager tableManager, TileState state, DrawArtifactTileEffectData data) : base(tableManager, state)
    {
        _artifactAmount = data.artifactAmount;
    }

    public override void Activate(Player player)
    {
        player.DrawArtifacts(_artifactAmount);
    }
}
