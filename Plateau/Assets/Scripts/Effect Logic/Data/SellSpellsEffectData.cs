using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Sell Spells")]
public class SellSpellsEffectData : EffectData
{
    public int amount;

    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new SellSpellsEffect(tableManager, state, description, amount);
    }
}
