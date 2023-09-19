using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePlayerMoveState : TableState
{
    private int _movement;

    public TablePlayerMoveState(TableManager tableManager, int movement) : base(tableManager)
    {
        _movement = movement;
    }

    public override void Enter()
    {
        TableManager.Player.Move(_movement);

        TableManager.ChangeState(new TableTileEffectState(TableManager));
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
