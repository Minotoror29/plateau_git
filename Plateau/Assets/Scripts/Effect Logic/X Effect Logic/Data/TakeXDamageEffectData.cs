using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Take X Damage")]
public class TakeXDamageEffectData : XEffectData
{
    public override XEffect Effect(TableManager tableManager, TileState state, int amount)
    {
        return new TakeXDamageEffect(tableManager, state, description, unit, amount);
    }
}
