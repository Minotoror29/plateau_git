using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEffect : Effect
{
    public FlipEffect(TableManager tableManager, FlipEffectData data) : base(tableManager, data)
    {
    }

    public override void Activate()
    {
        TableManager.Player.CurrentTile.FlipTile();

        ResolveEffect();
    }
}
