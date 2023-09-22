using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Flip")]
public class FlipEffectData : EffectData
{
    public override Effect Effect(TableManager tableManager)
    {
        return new FlipEffect(tableManager, description);
    }
}
