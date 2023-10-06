using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Sell")]
public class SellEffectData : EffectData
{
    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new SellEffect(tableManager, state, description);
    }
}
