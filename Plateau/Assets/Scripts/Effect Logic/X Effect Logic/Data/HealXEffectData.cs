using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Heal X")]
public class HealXEffectData : XEffectData
{
    public override XEffect Effect(TableManager tableManager, TileState state, int amount)
    {
        return new HealXEffect(tableManager, state, description, unit, amount);
    }
}
