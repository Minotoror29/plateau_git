using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEffect : Effect
{
    public FlipEffect(TableManager tableManager, string description) : base(tableManager, description)
    {
    }

    public override void Activate()
    {
        TableManager.Player.CurrentTile.FlipTile();

        ResolveEffect();
    }
}
