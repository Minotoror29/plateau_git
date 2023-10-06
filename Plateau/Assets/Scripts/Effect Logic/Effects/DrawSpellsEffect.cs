using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSpellsEffect : Effect
{
    private int _amount;

    public DrawSpellsEffect(TableManager tableManager, TileState state, DrawSpellsEffectData data, string description) : base(tableManager, state, description)
    {
        _amount = data.amount;
    }

    public override void Activate()
    {
        TableManager.Player.DrawSpells(_amount);
        if (TableManager.Player.Spells.Count > TableManager.Player.MaximumSpells)
        {
            TableManager.CurrentState.ChangeSubstate(new TableDiscardSpellSubstate(TableManager, TableManager.Player.Spells.Count - TableManager.Player.MaximumSpells, this));
        }
        else
        {
            ResolveEffect();
        }
    }
}
