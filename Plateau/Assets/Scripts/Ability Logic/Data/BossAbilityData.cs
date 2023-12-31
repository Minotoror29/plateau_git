using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Boss Ability")]
public class BossAbilityData : AbilityData
{
    public override Ability Ability(TableManager tableManager, TileState state)
    {
        return new BossAbility(tableManager, state, description);
    }
}
