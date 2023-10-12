using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThievesGuildAbility : Ability
{
    private Ability _loseGoldAbility;
    private Ability _loseArtifactsAbility;

    public ThievesGuildAbility(TableManager tableManager, TileState state, string description, ThievesGuildAbilityData data) : base(tableManager, state, description)
    {
        _loseGoldAbility = data.loseGoldAbility.Ability(tableManager, state);
        _loseArtifactsAbility = data.loseArtifactsAbility.Ability(tableManager, state);
    }

    public override void Activate()
    {
        if (TableManager.CurrentPlayer.Gold == 0 && TableManager.CurrentPlayer.Artifacts.Count == 0)
        {
            TableManager.CurrentPlayer.Die();
            ResolveAbility();
        } else if (TableManager.CurrentPlayer.Artifacts.Count == 0)
        {
            _loseGoldAbility.Activate();
        } else if (TableManager.CurrentPlayer.Gold < 5)
        {
            _loseArtifactsAbility.Activate();
        } else
        {
            TableManager.ModalAbilityDisplay.gameObject.SetActive(true);
            TableManager.ModalAbilityDisplay.Initialize(_loseGoldAbility, _loseArtifactsAbility);
        }
    }
}
