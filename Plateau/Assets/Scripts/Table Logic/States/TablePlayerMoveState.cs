using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePlayerMoveState : TableState
{
    private int _movement;

    public TablePlayerMoveState(TableManager tableManager, TableSubstate subState, int movement) : base(tableManager, subState)
    {
        _movement = movement;
    }

    public override void Enter()
    {
        TableManager.Player.Move(_movement);

        TableManager.ChangeState(new TableTileAbilityState(TableManager, CurrentSubstate));
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
