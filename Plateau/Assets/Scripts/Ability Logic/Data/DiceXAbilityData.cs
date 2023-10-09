using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Dice X Ability")]
public class DiceXAbilityData : AbilityData
{
    public List<XEffectData> effects;

    public override Ability Ability(TableManager tableManager, TileState state)
    {
        return new DiceXAbility(tableManager, state, description, effects);
    }
}
