using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceOrAbility : Ability
{
    private int _aimedResult;
    private Effect _resultEffect;
    private Effect _elseEffect;

    private int _result;

    public DiceOrAbility(TableManager tableManager, TileState state, string description, DiceOrAbilityData data) : base(tableManager, state, description)
    {
        _aimedResult = data.aimedResult;
        _resultEffect = data.resultEffect.Effect(tableManager, state);
        _elseEffect = data.elseEffect.Effect(tableManager, state);
    }

    public override void Activate()
    {
        _result = TableManager.TossDice();

        if (_result == _aimedResult)
        {
            ActivateEffect(_resultEffect);
        } else
        {
            ActivateEffect(_elseEffect);
        }
    }

    public void ActivateEffect(Effect effect)
    {
        effect.OnResolution += ResolveEffect;
        effect.Activate();
    }

    public void ResolveEffect()
    {
        if (_result == _aimedResult)
        {
            _resultEffect.OnResolution -= ResolveEffect;
        }
        else
        {
            _elseEffect.OnResolution -= ResolveEffect;
        }

        ResolveAbility();
    }
}
