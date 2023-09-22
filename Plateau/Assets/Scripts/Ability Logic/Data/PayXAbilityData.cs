using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Pay X Ability")]
public class PayXAbilityData : AbilityData
{
    public List<XEffectData> effects;

    public override Ability Ability(TableManager tableManager, TileState state)
    {
        return new PayXAbility(tableManager, state, effects);
    }
}
