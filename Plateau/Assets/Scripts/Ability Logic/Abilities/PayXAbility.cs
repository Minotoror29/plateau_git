using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayXAbility : Ability
{
    private List<XEffectData> _effectsData;
    private List<XEffect> _effects;
    private int _resolvedEffects;

    public PayXAbility(TableManager tableManager, TileState state, List<XEffectData> effects) : base(tableManager, state)
    {
        _effectsData = new();
        foreach (XEffectData effect in effects)
        {
            _effectsData.Add(effect);
        }
    }

    public override void Activate(Player player)
    {
        TableManager.PayXAbilityDisplay.gameObject.SetActive(true);
        TableManager.PayXAbilityDisplay.Initialize(TableManager.Player, this);
    }

    public void ActivateEffects(int goldAmount)
    {
        _effects = new();
        foreach (XEffectData effect in _effectsData)
        {
            XEffect newEffect = effect.Effect(TableManager, goldAmount);
            _effects.Add(newEffect);
            newEffect.OnResolution += ResolveEffect;
        }

        TableManager.Player.LoseGold(goldAmount);
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
