using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnStartState : TableState
{
    private Player _player;

    private int _fixedMovementValue;

    public int FixedmovementValue { set { _fixedMovementValue = value; } }

    public TableTurnStartState(TableManager tableManager, TableSubstate subState, Player player) : base(tableManager, subState)
    {
        _player = player;
    }

    public override void Enter()
    {
        TableManager.CurrentPlayer = _player;
        TableManager.PlayerTurnDisplay.text = TableManager.CurrentPlayer.PlayerName + "'s turn";

        TableManager.MoveButton.gameObject.SetActive(true);
        TableManager.MoveButton.onClick.AddListener(TossDice);

        TableManager.CurrentPlayer.StartTurn(this);
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
        TableManager.ChangeState(new TableDiceState(TableManager, CurrentSubstate));
    }

    public void MovePlayer()
    {
        TableManager.ChangeState(new TablePlayerMoveState(TableManager, CurrentSubstate, _fixedMovementValue));
    }
}
