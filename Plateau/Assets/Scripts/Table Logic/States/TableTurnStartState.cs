using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnStartState : TableState
{
    public TableTurnStartState(TableManager tableManager) : base(tableManager)
    {
    }

    public override void Enter()
    {
        TableManager.MoveButton.gameObject.SetActive(true);
        TableManager.MoveButton.onClick.AddListener(MovePlayer);
    }

    public override void Exit()
    {
        TableManager.MoveButton.gameObject.SetActive(false);
        TableManager.MoveButton.onClick.RemoveAllListeners();
    }

    public override void UpdateLogic()
    {
    }

    private void MovePlayer()
    {
        TableManager.ChangeState(new TablePlayerMoveState(TableManager));
    }
}
