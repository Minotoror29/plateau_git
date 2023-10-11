using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Draw Quest")]
public class DrawQuestEffectData : EffectData
{
    public int questAmount;

    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new DrawQuestEffect(tableManager, state, description, this);
    }
}
