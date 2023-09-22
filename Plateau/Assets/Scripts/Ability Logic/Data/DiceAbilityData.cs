using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Dice Ability")]
public class DiceAbilityData : AbilityData
{
    public int diceResult;
    public List<EffectData> effects;

    public override Ability Ability(TableManager tableManager, TileState state)
    {
        return new DiceAbility(tableManager, state, diceResult, effects);
    }
}
