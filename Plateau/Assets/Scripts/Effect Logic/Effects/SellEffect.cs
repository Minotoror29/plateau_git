using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellEffect : Effect
{
    public SellEffect(TableManager tableManager, TileState state, string description) : base(tableManager, state, description)
    {
    }

    public override void Activate()
    {
        TableManager.CurrentState.ChangeSubstate(new TableSellMerchandiseSubstate(TableManager, this));
    }

    public void Confirm()
    {
        TableManager.CurrentState.ChangeSubstate(new TableDefaultSubstate(TableManager));
        State.FlipTile();
        ResolveEffect();
    }
}
