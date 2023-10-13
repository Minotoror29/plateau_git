using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayAbility : Ability
{
    private ResourceData _resource;
    private int _amount;

    private List<Effect> _effects;
    private int _resolvedEffects;

    public PayAbility(TableManager tableManager, TileState state, string description, PayAbilityData data) : base(tableManager, state, description)
    {
        _resource =  data.resource;
        _amount = data.amount;

        _effects = new();
        foreach (EffectData effect in data.effects)
        {
            _effects.Add(effect.Effect(TableManager, state));
        }
    }

    public override void Activate()
    {
        TableManager.PayAbilityDisplay.gameObject.SetActive(true);
        TableManager.PayAbilityDisplay.Initialize(TableManager.CurrentPlayer, this, _resource, _amount);
    }

    public void ActivateEffects()
    {
        foreach (Effect effect in _effects)
        {
            effect.OnResolution += ResolveEffect;
        }

        _resource.LoseResource(TableManager.CurrentPlayer, _amount);
        _resolvedEffects = 0;
        ActivateNextEffect();
    }

    public void ActivateNextEffect()
    {
        _effects[_resolvedEffects].Activate();
    }

    public void ResolveEffect()
    {
        _effects[_resolvedEffects].OnResolution -= ResolveEffect;

        _resolvedEffects++;

        if (_resolvedEffects == _effects.Count)
        {
            ResolveAbility();
        }
        else
        {
            ActivateNextEffect();
        }
    }
}
