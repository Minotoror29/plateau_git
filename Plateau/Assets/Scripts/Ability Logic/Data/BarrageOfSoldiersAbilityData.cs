using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Barrage of Soldiers Ability")]
public class BarrageOfSoldiersAbilityData : AbilityData
{
    public override Ability Ability(TableManager tableManager, TileState state)
    {
        return new BarrageOfSoldiersAbility(tableManager, state, description);
    }
}
