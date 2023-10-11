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
        TableManager.CurrentPlayer.DrawSpells(_amount);
        if (TableManager.CurrentPlayer.Spells.Count > TableManager.CurrentPlayer.MaximumSpells)
        {
            TableManager.CurrentState.ChangeSubstate(new TableDiscardSpellSubstate(TableManager, TableManager.CurrentPlayer.Spells.Count - TableManager.CurrentPlayer.MaximumSpells, this));
        }
        else
        {
            ResolveEffect();
        }
    }
}
