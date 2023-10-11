using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTileAbilityState : TableState
{
    public TableTileAbilityState(TableManager tableManager, TableSubstate subState) : base(tableManager, subState)
    {
    }

    public override void Enter()
    {
        TableManager.CurrentPlayer.CurrentTile.ActivateAbilities();
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
