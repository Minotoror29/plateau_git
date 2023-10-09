using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Dice or Ability")]
public class DiceOrAbilityData : AbilityData
{
    public int aimedResult;
    public EffectData resultEffect;
    public EffectData elseEffect;

    public override Ability Ability(TableManager tableManager, TileState state)
    {
        return new DiceOrAbility(tableManager, state, description, this);
    }
}
