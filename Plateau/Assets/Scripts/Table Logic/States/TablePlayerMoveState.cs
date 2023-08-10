using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePlayerMoveState : TableState
{
    public TablePlayerMoveState(TableManager tableManager) : base(tableManager)
    {
    }

    public override void Enter()
    {
        TableManager.Player.Move(TableManager.TossDice());

        TableManager.ChangeState(new TableTileEffectState(TableManager));
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
