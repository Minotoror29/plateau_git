using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Combat")]
public class CombatEffectData : EffectData
{
    [Range(1, 6)] public int health;
    public int attack;
    public List<CombatRewardData> rewards;
    public List<AdditionalCombatEffectData> additionalCombatEffects;

    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new CombatEffect(tableManager, state, description, this);
    }
}
