using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Take Damage")]
public class TakeDamageEffectData : EffectData
{
    public int damageAmount;

    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new TakeDamageEffect(tableManager, state, description, this);
    }
}
