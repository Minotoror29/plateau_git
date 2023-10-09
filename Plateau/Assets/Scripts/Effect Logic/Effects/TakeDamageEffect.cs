using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageEffect : Effect
{
    private int _damageAmount;

    public TakeDamageEffect(TableManager tableManager, TileState state, string description, TakeDamageEffectData data) : base(tableManager, state, description)
    {
        _damageAmount = data.damageAmount;
    }

    public override void Activate()
    {
        TableManager.Player.TakeDamage(_damageAmount);
    }
}
