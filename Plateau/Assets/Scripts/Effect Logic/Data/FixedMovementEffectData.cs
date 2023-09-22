using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Fixed Movement")]
public class FixedMovementEffectData : EffectData
{
    public int movementValue;

    public override Effect Effect(TableManager tableManager)
    {
        return new FixedMovementEffect(tableManager, description, movementValue);
    }
}
