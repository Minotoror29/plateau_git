using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableDiceState : TableState
{
    private int _movement;

    public TableDiceState(TableManager tableManager, TableSubstate subState) : base(tableManager, subState)
    {
    }

    public override void Enter()
    {
        _movement = TableManager.TossDice();
        TableManager.ChangeState(new TablePlayerMoveState(TableManager, CurrentSubstate, _movement));
    }

    public override void Exit()
    {
        
    }

    public override void UpdateLogic()
    {
        
    }
}
