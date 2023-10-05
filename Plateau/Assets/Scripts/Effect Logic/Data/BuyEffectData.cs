using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Buy")]
public class BuyEffectData : EffectData
{
    public int merchandiseToReveal;
    public int merchandiseToBuy;

    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new BuyEffect(tableManager, state, description, merchandiseToReveal, merchandiseToBuy);
    }
}
