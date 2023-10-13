using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawArtifactsEffect : Effect
{
    private int _artifactAmount;

    public DrawArtifactsEffect(TableManager tableManager, TileState state, DrawArtifactsEffectData data, string description) : base(tableManager, state, description)
    {
        _artifactAmount = data.artifactAmount;
    }

    public override void Activate()
    {
        TableManager.CurrentPlayer.DrawArtifacts(_artifactAmount);
        if (TableManager.CurrentPlayer.Artifacts.Count > TableManager.CurrentPlayer.MaximumArtifacts)
        {
            TableManager.CurrentState.ChangeSubstate(new TableDiscardArtifactSubstate(TableManager, TableManager.CurrentPlayer.Artifacts.Count - TableManager.CurrentPlayer.MaximumArtifacts, this));
        } else
        {
            ResolveEffect();
        }
    }
}
