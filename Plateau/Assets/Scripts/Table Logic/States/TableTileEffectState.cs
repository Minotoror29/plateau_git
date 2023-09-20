using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTileEffectState : TableState
{
    public TableTileEffectState(TableManager tableManager) : base(tableManager)
    {
    }

    public override void Enter()
    {
        TableManager.Player.CurrentTile.ActivateEffects(TableManager.Player);
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
