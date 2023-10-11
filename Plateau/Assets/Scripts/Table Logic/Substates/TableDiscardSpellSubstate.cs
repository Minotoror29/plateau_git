using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableDiscardSpellSubstate : TableSubstate
{
    private int _spellsToDiscard;
    private Effect _effect;

    public TableDiscardSpellSubstate(TableManager tableManager, int artifactsToDiscard, Effect effect) : base(tableManager)
    {
        _spellsToDiscard = artifactsToDiscard;
        _effect = effect;
    }

    public override void Enter()
    {
        TableManager.DiscardMerchandiseDisplay.gameObject.SetActive(true);
        TableManager.DiscardMerchandiseDisplay.Initialize(TableManager.CurrentPlayer.PlayerName, "spell");
    }

    public override void SelectSpell(HandSpellDisplay spell, Player player)
    {
        base.SelectSpell(spell, player);

        if (player != TableManager.CurrentPlayer) return;

        TableManager.CurrentPlayer.DiscardSpell(spell);
        _spellsToDiscard--;

        if (_spellsToDiscard == 0)
        {
            _effect.ResolveEffect();
            CurrentSuperstate.ChangeSubstate(new TableDefaultSubstate(TableManager));
        }
    }

    public override void Exit()
    {
        TableManager.DiscardMerchandiseDisplay.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
    }
}
