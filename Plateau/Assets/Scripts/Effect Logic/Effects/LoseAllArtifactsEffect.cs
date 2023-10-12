using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseAllArtifactsEffect : Effect
{
    public LoseAllArtifactsEffect(TableManager tableManager, TileState state, string description) : base(tableManager, state, description)
    {
    }

    public override void Activate()
    {
        TableManager.CurrentPlayer.DiscardAllArtifacts();
        ResolveEffect();
    }
}
