using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellSpellsEffect : SellEffect
{
    private int _amount;

    public SellSpellsEffect(TableManager tableManager, TileState state, string description, int amount) : base(tableManager, state, description)
    {
        _amount = amount;
    }

    public override void Activate()
    {
        TableManager.CurrentState.ChangeSubstate(new TableSellSpellsSubstate(TableManager, this, _amount));
    }
}
