using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Heal")]
public class HealEffectData : EffectData
{
    public int healthAmount;

    public override Effect Effect(TableManager tableManager)
    {
        return new HealEffect(tableManager, this);
    }
}
