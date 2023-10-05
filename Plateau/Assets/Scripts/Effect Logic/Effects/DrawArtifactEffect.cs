using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawArtifactEffect : Effect
{
    private int _artifactAmount;

    public DrawArtifactEffect(TableManager tableManager, DrawArtifactEffectData data, string description) : base(tableManager, description)
    {
        _artifactAmount = data.artifactAmount;
    }

    public override void Activate()
    {
        TableManager.Player.DrawArtifacts(_artifactAmount);
        if (TableManager.Player.Artifacts.Count > TableManager.Player.MaximumArtifacts)
        {
            TableManager.CurrentState.ChangeSubstate(new TableDiscardArtifactSubstate(TableManager, TableManager.Player.Artifacts.Count - TableManager.Player.MaximumArtifacts, this));
        } else
        {
            ResolveEffect();
        }
    }
}
