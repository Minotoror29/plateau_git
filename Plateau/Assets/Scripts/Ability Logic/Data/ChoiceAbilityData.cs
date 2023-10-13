using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Choice Ability")]
public class ChoiceAbilityData : AbilityData
{
    public AbilityData ability;

    public override Ability Ability(TableManager tableManager, TileState state)
    {
        return new ChoiceAbility(tableManager, state, description, this);
    }
}
