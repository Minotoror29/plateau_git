using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Toll Collector Troll Ability")]
public class TollCollectorTrollAbilityData : AbilityData
{
    public override Ability Ability(TableManager tableManager, TileState state)
    {
        return new TollCollectorTrollAbility(tableManager, state, description);
    }
}
