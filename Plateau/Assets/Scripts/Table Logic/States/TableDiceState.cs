using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableDiceState : TableState
{
    private int _movement;

    public TableDiceState(TableManager tableManager) : base(tableManager)
    {
    }

    public override void Enter()
    {
        Debug.Log(this);

        _movement = TableManager.TossDice();
        TableManager.ChangeState(new TablePlayerMoveState(TableManager, _movement));
    }

    public override void Exit()
    {
        
    }

    public override void UpdateLogic()
    {
        
    }
}
