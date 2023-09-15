using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Effect/Combat")]
public class CombatTileEffectData : TileEffectData
{
    [Range(1, 6)] public int health;
    public int attack;
    public CombatRewardData reward;

    public override TileEffect Effect(TableManager tableManager)
    {
        return new CombatTileEffect(tableManager, this);
    }
}
