using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Effect/Earn Gold")]
public class EarnGoldTileEffectData : TileEffectData
{
    public int goldAmount;

    public override void Activate(TableManager tableManager, Player player)
    {
        player.EarnGold(goldAmount);
    }
}
