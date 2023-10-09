using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Move")]
public class MoveEffectData : EffectData
{
    public int movementAmount;

    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new MoveEffect(tableManager, state, description, this);
    }
}
