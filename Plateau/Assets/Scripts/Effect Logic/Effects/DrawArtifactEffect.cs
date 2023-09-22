using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawArtifactEffect : Effect
{
    private int _artifactAmount;

    public DrawArtifactEffect(TableManager tableManager, DrawArtifactEffectData data) : base(tableManager, data)
    {
        _artifactAmount = data.artifactAmount;
    }

    public override void Activate()
    {
        TableManager.Player.DrawArtifacts(_artifactAmount);
        ResolveEffect();
    }
}
