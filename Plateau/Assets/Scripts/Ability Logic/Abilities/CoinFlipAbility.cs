using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFlipAbility : Ability
{
    private Effect _evenEffect;
    private Effect _oddEffect;

    private int _result;

    public CoinFlipAbility(TableManager tableManager, TileState state, string description, CoinFlipAbilityData data) : base(tableManager, state, description)
    {
        _evenEffect = data.evenEffect.Effect(tableManager, state);
        _oddEffect = data.oddEffect.Effect(tableManager, state);
    }

    public override void Activate()
    {
        _result = TableManager.TossDice();

        if (_result % 2 == 0)
        {
            ActivateEffect(_evenEffect);
        } else
        {
            ActivateEffect(_oddEffect);
        }
    }

    public void ActivateEffect(Effect effect)
    {
        effect.OnResolution += ResolveEffect;
        effect.Activate();
    }

    public void ResolveEffect()
    {
        if (_result % 2 == 0)
        {
            _evenEffect.OnResolution -= ResolveEffect;
        } else
        {
            _oddEffect.OnResolution -= ResolveEffect;
        }

        ResolveAbility();
    }
}
