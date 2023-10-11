using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHealthAbility : Ability
{
    private int _healthAmount;
    private Effect _effect;

    public CheckHealthAbility(TableManager tableManager, TileState state, string description, CheckHealthAbilityData data) : base(tableManager, state, description)
    {
        _healthAmount = data.healthAmount;
        _effect = data.effect.Effect(TableManager, state);  
    }

    public override void Activate()
    {
        if (TableManager.CurrentPlayer.Health == _healthAmount)
        {
            _effect.OnResolution += ResolveEffect;
            _effect.Activate();
        } else
        {
            ResolveAbility();
        }
    }

    public void ResolveEffect()
    {
        _effect.OnResolution -= ResolveEffect;
        ResolveAbility();
    }
}
