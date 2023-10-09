using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEffect : Effect
{
    private int _movementAmount;

    public MoveEffect(TableManager tableManager, TileState state, string description, MoveEffectData data) : base(tableManager, state, description)
    {
        _movementAmount = data.movementAmount;
    }

    public override void Activate()
    {
        //A REVOIR
        TableManager.ChangeState(new TablePlayerMoveState(TableManager, TableManager.CurrentState.CurrentSubstate, _movementAmount));
    }
}
