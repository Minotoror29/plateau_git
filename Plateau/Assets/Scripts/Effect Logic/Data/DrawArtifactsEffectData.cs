using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Draw Artifacts")]
public class DrawArtifactsEffectData : EffectData
{
    public int artifactAmount;

    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new DrawArtifactsEffect(tableManager, state, this, description);
    }
}
