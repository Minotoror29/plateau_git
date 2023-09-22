using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Heal X")]
public class HealXEffectData : XEffectData
{
    public override XEffect Effect(TableManager tableManager, int amount)
    {
        return new HealXEffect(tableManager, description, unit, amount);
    }
}
