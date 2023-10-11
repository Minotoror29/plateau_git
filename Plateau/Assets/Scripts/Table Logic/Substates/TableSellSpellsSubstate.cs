using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class TableSellSpellsSubstate : TableSubstate
{
    private SellMerchandiseDisplay _display;
    private SellSpellsEffect _effect;
    private int _amount;
    private int _soldSpells = 0;

    public TableSellSpellsSubstate(TableManager tableManager, SellSpellsEffect effect, int amount) : base(tableManager)
    {
        _display = TableManager.SellMerchandiseDisplay;
        _effect = effect;
        _amount = amount;
    }

    public override void Enter()
    {
        _display.gameObject.SetActive(true);
        _display.Initialize(_effect, "spell", _amount);
    }

    public override void Exit()
    {
        _display.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
    }

    public override void SelectSpell(HandSpellDisplay spell, Player player)
    {
        base.SelectSpell(spell, player);

        TableManager.CurrentPlayer.EarnGold(spell.SpellData.goldValue);
        TableManager.CurrentPlayer.DiscardSpell(spell);

        _soldSpells++;

        if (_soldSpells == _amount)
        {
            _effect.Confirm();
        }
    }
}
