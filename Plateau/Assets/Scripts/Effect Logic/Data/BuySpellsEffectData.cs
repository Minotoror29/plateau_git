using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Buy Spells")]
public class BuySpellsEffectData : EffectData
{
    public int spellstoReveal;
    public int spellsToBuy;

    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new BuySpellsEffect(tableManager, state, description, this);
    }
}
