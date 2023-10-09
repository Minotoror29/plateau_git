using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Check Health Ability")]
public class CheckHealthAbilityData : AbilityData
{
    public int healthAmount;
    public EffectData effect;

    public override Ability Ability(TableManager tableManager, TileState state)
    {
        return new CheckHealthAbility(tableManager, state, description, this);
    }
}
