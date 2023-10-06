using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Draw Spells")]
public class DrawSpellsEffectData : EffectData
{
    public int amount;

    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new DrawSpellsEffect(tableManager, state, this, description);
    }
}
