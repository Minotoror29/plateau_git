using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayXAbility : Ability
{
    private List<XEffectData> _effectsData;
    private List<XEffect> _effects;
    private int _resolvedEffects;

    public PayXAbility(TableManager tableManager, TileState state, string description, List<XEffectData> effects) : base(tableManager, state, description)
    {
        _effectsData = new();
        foreach (XEffectData effect in effects)
        {
            _effectsData.Add(effect);
        }
    }

    public override void Activate()
    {
        TableManager.PayXAbilityDisplay.gameObject.SetActive(true);
        TableManager.PayXAbilityDisplay.Initialize(TableManager.CurrentPlayer, this);
    }

    public void ActivateEffects(int goldAmount)
    {
        _effects = new();
        foreach (XEffectData effect in _effectsData)
        {
            XEffect newEffect = effect.Effect(TableManager, State, goldAmount);
            _effects.Add(newEffect);
            newEffect.OnResolution += ResolveEffect;
        }

        TableManager.CurrentPlayer.LoseGold(goldAmount);
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
            _effects.Clear();
            ResolveAbility();
        }
        else
        {
            ActivateNextEffect();
        }
    }
}
