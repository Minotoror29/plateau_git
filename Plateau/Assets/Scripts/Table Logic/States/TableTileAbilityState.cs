using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTileAbilityState : TableState
{
    public TableTileAbilityState(TableManager tableManager) : base(tableManager)
    {
    }

    public override void Enter()
    {
        TableManager.Player.CurrentTile.ActivateAbilities();
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
