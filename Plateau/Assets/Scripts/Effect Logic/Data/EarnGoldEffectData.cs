using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Earn Gold")]
public class EarnGoldEffectData : EffectData
{
    public int goldAmount;

    public override Effect Effect(TableManager tableManager)
    {
        return new EarnGoldEffect(tableManager, description, goldAmount);
    }
}
