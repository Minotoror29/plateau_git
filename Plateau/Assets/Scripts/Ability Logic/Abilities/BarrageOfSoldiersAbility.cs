using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageOfSoldiersAbility : Ability
{
    public BarrageOfSoldiersAbility(TableManager tableManager, TileState state, string description) : base(tableManager, state, description)
    {
    }

    public override void Activate()
    {
        if (TableManager.CurrentPlayer.Gold < 10 && TableManager.CurrentPlayer.Artifacts.Count >= 3)
        {
            TableManager.CurrentPlayer.Die();
            ResolveAbility();
        } else
        {
            TableManager.ChangeState(new TablePlayerMoveState(TableManager, TableManager.CurrentState.CurrentSubstate, 3));
        }
    }
}
