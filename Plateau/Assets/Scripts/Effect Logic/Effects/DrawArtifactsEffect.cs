using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawArtifactsEffect : Effect
{
    private int _amount;

    public DrawArtifactsEffect(TableManager tableManager, TileState state, DrawArtifactsEffectData data, string description) : base(tableManager, state, description)
    {
        _amount = data.amount;
    }

    public override void Activate()
    {
        TableManager.CurrentPlayer.DrawArtifacts(_amount);
        if (TableManager.CurrentPlayer.Artifacts.Count > TableManager.CurrentPlayer.MaximumArtifacts)
        {
            TableManager.CurrentState.ChangeSubstate(new TableDiscardArtifactSubstate(TableManager, TableManager.CurrentPlayer.Artifacts.Count - TableManager.CurrentPlayer.MaximumArtifacts, this));
        } else
        {
            ResolveEffect();
        }
    }
}
