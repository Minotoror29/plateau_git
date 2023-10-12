using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Lose All Gold")]
public class LoseAllGoldEffectData : EffectData
{
    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new LoseAllGoldEffect(tableManager, state, description);
    }
}
