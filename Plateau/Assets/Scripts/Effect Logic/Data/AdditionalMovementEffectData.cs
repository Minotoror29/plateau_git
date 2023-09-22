using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Additional Movement")]
public class AdditionalMovementEffectData : EffectData
{
    public override Effect Effect(TableManager tableManager)
    {
        return new AdditionalMovementEffect(tableManager, description);
    }
}
