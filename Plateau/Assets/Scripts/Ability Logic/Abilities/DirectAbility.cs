using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectAbility : Ability
{
    private List<Effect> _effects;
    private int _resolvedEffects;

    public DirectAbility(TableManager tableManager, TileState state, string description, List<EffectData> effects) : base(tableManager, state, description)
    {
        _effects = new();
        foreach (EffectData effect in effects)
        {
            _effects.Add(effect.Effect(TableManager, state));
        }
    }

    public override void Activate()
    {
        ActivateEffects();
    }

    private void ActivateEffects()
    {
        foreach (Effect effect in _effects)
        {
            effect.OnResolution += ResolveEffect;
        }

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

        if (_resolvedEffects == _effects.Count )
        {
            ResolveAbility();
        } else
        {
            ActivateNextEffect();
        }
    }
}
