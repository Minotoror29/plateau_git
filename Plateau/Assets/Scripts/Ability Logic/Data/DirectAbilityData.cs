using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Direct Ability")]
public class DirectAbilityData : AbilityData
{
    public List<TileEffectData> effects;

    public override Ability Ability(TableManager tableManager, TileState state)
    {
        return new DirectAbility();
    }
}
