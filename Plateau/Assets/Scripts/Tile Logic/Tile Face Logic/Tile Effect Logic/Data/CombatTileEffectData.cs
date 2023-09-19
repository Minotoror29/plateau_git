using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Effect/Combat")]
public class CombatTileEffectData : TileEffectData
{
    [Range(1, 6)] public int health;
    public int attack;
    public List<CombatRewardData> rewards;
    public List<AdditionalCombatEffectData> additionalCombatEffects;

    public override TileEffect Effect(TableManager tableManager, TileState state)
    {
        return new CombatTileEffect(tableManager, state, this, additionalCombatEffects);
    }
}
