using Mino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationEffect : Effect
{
    public TeleportationEffect(TableManager tableManager, TileState state, string description) : base(tableManager, state, description)
    {
    }

    public override void Activate()
    {
        TableManager.CurrentState.ChangeSubstate(new TableSelectTileSubstate(TableManager, this));
    }

    public void Confirm(Tile tile)
    {
        TableManager.CurrentPlayer.MoveTo(tile);

        if (TableManager.CurrentPlayer.CurrentTile.PlayersOnTheTile.Count > 1)
        {
            TableManager.ChangeState(new TableChifumiState(TableManager, TableManager.CurrentState.CurrentSubstate));
        }
        else
        {
            TableManager.ChangeState(new TableTileAbilityState(TableManager, TableManager.CurrentState.CurrentSubstate));
        }
    }
}
