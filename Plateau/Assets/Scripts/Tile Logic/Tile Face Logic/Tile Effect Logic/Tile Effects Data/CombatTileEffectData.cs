using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Effect/Combat")]
public class CombatTileEffectData : TileEffectData
{
    public int health;
    public int attack;
    public int goldReward;

    public override void Activate(TableManager tableManager, Player player)
    {
        int playerDamage = tableManager.TossDice();

        if (playerDamage >= health)
        {
            player.EarnGold(goldReward);
            player.CurrentTile.SwithFace();
        } else
        {
            player.TakeDamage(attack);
        }
    }
}
