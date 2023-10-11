using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEffect : Effect
{
    public FlipEffect(TableManager tableManager, TileState state, string description) : base(tableManager, state, description)
    {
    }

    public override void Activate()
    {
        TableManager.CurrentPlayer.CurrentTile.FlipTile();

        ResolveEffect();
    }
}
