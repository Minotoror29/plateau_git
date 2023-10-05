using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceAbility : Ability
{
    private int _diceResult;

    private List<Effect> _effects;
    private int _resolvedEffects;

    public DiceAbility(TableManager tableManager, TileState state, int diceResult, List<EffectData> effects) : base(tableManager, state)
    {
        _diceResult = diceResult;

        _effects = new();
        foreach (EffectData effect in effects)
        {
            _effects.Add(effect.Effect(TableManager, state));
        }
    }

    public override void Activate(Player player)
    {
        if (TableManager.TossDice() == _diceResult)
        {
            ActivateEffects();
        } else
        {
            ResolveAbility();
        }
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
