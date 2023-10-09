using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Modal Ability")]
public class ModalAbilityData : AbilityData
{
    public AbilityData ability1;
    public AbilityData ability2;

    public override Ability Ability(TableManager tableManager, TileState state)
    {
        return new ModalAbility(tableManager, state, description, this);
    }
}
