using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Draw Artifacts")]
public class DrawArtifactEffectData : EffectData
{
    public int artifactAmount;

    public override Effect Effect(TableManager tableManager)
    {
        return new DrawArtifactEffect(tableManager, this, description);
    }
}
