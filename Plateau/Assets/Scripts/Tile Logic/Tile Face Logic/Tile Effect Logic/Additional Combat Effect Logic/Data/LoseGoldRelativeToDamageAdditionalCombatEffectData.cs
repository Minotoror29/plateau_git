using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Additional Combat Effect/Lose Gold Relative to Damage")]
public class LoseGoldRelativeToDamageAdditionalCombatEffectData : AdditionalCombatEffectData
{
    public override AdditionalCombatEffect Effect(CombatTileEffectData combat)
    {
        return new LoseGoldRelativeToDamageAdditionalCombatEffect(combat);
    }
}
