using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckChifumiAbility : Ability
{
    private Effect _effect;

    public CheckChifumiAbility(TableManager tableManager, TileState state, string description, CheckChifumiAbilityData data) : base(tableManager, state, description)
    {
        _effect = data.effect.Effect(TableManager, state);
    }

    public override void Activate()
    {
        if (TableManager.CurrentPlayer.CurrentTile.PlayersOnTheTile.Count > 1)
        {
            _effect.OnResolution += ResolveEffect;
            _effect.Activate();
        } else
        {
            ResolveAbility();
        }
    }

    private void ResolveEffect()
    {
        _effect.OnResolution -= ResolveEffect;

        ResolveAbility();
    }
}
