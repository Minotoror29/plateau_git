using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCheckState : TableState
{
    public TableCheckState(TableManager tableManager, TableSubstate subState) : base(tableManager, subState)
    {
    }

    public override void Enter()
    {
        if (TableManager.CurrentPlayer.Health == 0)
        {
            TableManager.CurrentPlayer.ResetStats();
            TableManager.CurrentPlayer.MoveTo(TableManager.Tiles[TableManager.InnTileIndex]);
        }

        TableManager.ChangeState(new TableTurnStartState(TableManager, CurrentSubstate, TableManager.Players[(TableManager.Players.IndexOf(TableManager.CurrentPlayer) + 1) % TableManager.Players.Count]));
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
