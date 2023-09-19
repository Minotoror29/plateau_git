using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTileEffect : TileEffect
{
    public FlipTileEffect(TableManager tableManager, TileState state) : base(tableManager, state)
    {
    }

    public override void Activate(Player player)
    {
        player.CurrentTile.FlipTile();

        Resolve();
    }
}
