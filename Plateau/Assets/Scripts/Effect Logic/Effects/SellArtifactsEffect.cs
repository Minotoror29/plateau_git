using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellArtifactsEffect : SellEffect
{
    public SellArtifactsEffect(TableManager tableManager, TileState state, string description) : base(tableManager, state, description)
    {
    }

    public override void Activate()
    {
        TableManager.CurrentState.ChangeSubstate(new TableSellArtifactsSubstate(TableManager, this));
    }
}
