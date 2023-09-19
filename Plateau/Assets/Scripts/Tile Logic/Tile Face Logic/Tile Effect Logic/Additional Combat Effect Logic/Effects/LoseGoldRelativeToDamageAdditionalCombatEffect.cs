using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGoldRelativeToDamageAdditionalCombatEffect : AdditionalCombatEffect
{
    public LoseGoldRelativeToDamageAdditionalCombatEffect(CombatTileEffectData combat) : base(combat)
    {
    }

    public override void Activate(Player player)
    {
        player.LoseGold(Combat.attack);
    }
}
