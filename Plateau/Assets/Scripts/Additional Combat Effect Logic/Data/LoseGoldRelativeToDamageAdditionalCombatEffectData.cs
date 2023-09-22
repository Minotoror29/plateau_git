using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Additional Combat Effect/Lose Gold Relative to Damage")]
public class LoseGoldRelativeToDamageAdditionalCombatEffectData : AdditionalCombatEffectData
{
    public override AdditionalCombatEffect Effect(CombatAbilityData combat)
    {
        return new LoseGoldRelativeToDamageAdditionalCombatEffect(combat);
    }
}
