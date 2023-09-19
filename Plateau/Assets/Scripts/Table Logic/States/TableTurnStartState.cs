using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnStartState : TableState
{
    private int _fixedMovementValue;

    public int FixedmovementValue { set { _fixedMovementValue = value; } }

    public TableTurnStartState(TableManager tableManager) : base(tableManager)
    {
    }

    public override void Enter()
    {
        TableManager.MoveButton.gameObject.SetActive(true);
        TableManager.MoveButton.onClick.AddListener(TossDice);

        TableManager.Player.StartTurn(this);
    }

    public override void Exit()
    {
        TableManager.MoveButton.gameObject.SetActive(false);
        TableManager.MoveButton.onClick.RemoveAllListeners();
    }

    public override void UpdateLogic()
    {
    }

    private void TossDice()
    {
        TableManager.ChangeState(new TableDiceState(TableManager));
    }

    public void MovePlayer()
    {
        TableManager.ChangeState(new TablePlayerMoveState(TableManager, _fixedMovementValue));
    }
}
