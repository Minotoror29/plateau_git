using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Pay Ability")]
public class PayAbilityData : AbilityData
{
    public ResourceData resource;
    public int amount;
    public List<EffectData> effects;

    public override Ability Ability(TableManager tableManager, TileState state)
    {
        return new PayAbility(tableManager, state, description, this);
    }
}
