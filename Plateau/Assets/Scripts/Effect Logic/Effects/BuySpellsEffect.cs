using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySpellsEffect : Effect
{
    private int _spellsToReveal;
    private int _spellsToBuy;

    public BuySpellsEffect(TableManager tableManager, TileState state, string description, BuySpellsEffectData data) : base(tableManager, state, description)
    {
        _spellsToReveal = data.spellstoReveal;
        _spellsToBuy = data.spellsToBuy;
    }

    public override void Activate()
    {
        TableManager.BuySpellsDisplay.gameObject.SetActive(true);
        TableManager.BuySpellsDisplay.SetEffect(this);
        TableManager.BuySpellsDisplay.SetSpells(_spellsToReveal, _spellsToBuy);
    }

    public void Confirm(int boughtSpells)
    {
        TableManager.BuySpellsDisplay.gameObject.SetActive(false);

        if (boughtSpells >= _spellsToBuy)
        {
            State.FlipTile();
        }

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
