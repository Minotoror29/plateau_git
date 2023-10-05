using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Heal")]
public class HealEffectData : EffectData
{
    public int healthAmount;

    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new HealEffect(tableManager, state, this, description);
    }
}
