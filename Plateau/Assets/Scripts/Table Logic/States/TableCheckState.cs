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
        if (TableManager.Player.Health == 0)
        {
            TableManager.Player.ResetStats();
            TableManager.Player.MoveTo(TableManager.Tiles[TableManager.InnTileIndex]);
        }

        if (TableManager.Player.Artifacts.Count > TableManager.Player.MaximumArtifacts)
        {
            TableManager.ChangeState(new TableDiscardArtifactState(TableManager, CurrentSubstate, TableManager.Player.Artifacts.Count - TableManager.Player.MaximumArtifacts));
        } else
        {
            TableManager.ChangeState(new TableTurnStartState(TableManager, CurrentSubstate));
        }

    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
