using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Flip")]
public class FlipEffectData : EffectData
{
    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new FlipEffect(tableManager, state, description);
    }
}
