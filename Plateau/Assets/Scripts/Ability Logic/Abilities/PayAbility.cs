using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayAbility : Ability
{
    private int _goldAmount;

    private List<Effect> _effects;
    private int _resolvedEffects;

    public List<Effect> Effects { get { return _effects; } }

    public PayAbility(TableManager tableManager, TileState state, int goldAmount, List<EffectData> effects) : base(tableManager, state)
    {
        _goldAmount = goldAmount;

        _effects = new();
        foreach (EffectData effect in effects)
        {
            _effects.Add(effect.Effect(TableManager));
        }
    }

    public override void Activate(Player player)
    {
        TableManager.PayAbilityDisplay.gameObject.SetActive(true);
        TableManager.PayAbilityDisplay.Initialize(player, this, _goldAmount);
    }

    public void ActivateEffects()
    {
        foreach (Effect effect in _effects)
        {
            effect.OnResolution += ResolveEffect;
        }

        TableManager.Player.LoseGold(_goldAmount);
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
