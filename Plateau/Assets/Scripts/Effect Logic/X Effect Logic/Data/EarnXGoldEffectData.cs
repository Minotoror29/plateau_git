using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Earn X Gold")]
public class EarnXGoldEffectData : XEffectData
{
    public override XEffect Effect(TableManager tableManager, TileState state, int amount)
    {
        return new EarnXGold(tableManager, state, description, unit, amount);
    }
}
