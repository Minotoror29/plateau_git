using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Combat")]
public class CombatAbilityData : AbilityData
{
    [Range(1, 6)] public int health;
    public int attack;
    public List<CombatRewardData> rewards;
    public List<AdditionalCombatEffectData> additionalCombatEffects;

    public override Ability Ability(TableManager tableManager, TileState state)
    {
        return new CombatAbility(tableManager, state, this, additionalCombatEffects);
    }
}
