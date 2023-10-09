using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SellEffect : Effect
{
    protected SellEffect(TableManager tableManager, TileState state, string description) : base(tableManager, state, description)
    {
    }

    public void Confirm()
    {
        TableManager.CurrentState.ChangeSubstate(new TableDefaultSubstate(TableManager));
        ResolveEffect();
    }
}
