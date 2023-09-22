using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEffect : Effect
{
    public FlipEffect(TableManager tableManager) : base(tableManager)
    {
    }

    public override void Activate()
    {
        TableManager.Player.CurrentTile.FlipTile();

        ResolveEffect();
    }
}
