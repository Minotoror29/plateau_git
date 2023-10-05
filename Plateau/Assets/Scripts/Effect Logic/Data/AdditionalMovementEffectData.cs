using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Additional Movement")]
public class AdditionalMovementEffectData : EffectData
{
    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new AdditionalMovementEffect(tableManager, state, description);
    }
}
