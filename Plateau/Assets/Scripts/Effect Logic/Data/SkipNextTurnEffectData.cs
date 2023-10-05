using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Skip Next Turn")]
public class SkipNextTurnEffectData : EffectData
{
    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new SkipNextTurnEffect(tableManager, state, description);
    }
}
