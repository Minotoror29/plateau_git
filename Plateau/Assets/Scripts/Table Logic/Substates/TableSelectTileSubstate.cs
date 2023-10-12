using Mino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSelectTileSubstate : TableSubstate
{
    private TeleportationEffect _effect;

    public TableSelectTileSubstate(TableManager tableManager, TeleportationEffect effect) : base(tableManager)
    {
        _effect = effect;
    }

    public override void Enter()
    {
        TableManager.TeleportationDisplay.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        TableManager.TeleportationDisplay.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
    }

    public override void SelectTile(Tile tile)
    {
        base.SelectTile(tile);

        if (tile == TableManager.CurrentPlayer.CurrentTile) return;

        _effect.Confirm(tile);
    }
}
