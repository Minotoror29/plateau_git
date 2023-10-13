using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Resource/Gold")]
public class GoldResourceData : ResourceData
{
    public override void LoseResource(Player player, int amount)
    {
        player.LoseGold(amount);
    }

    public override int PlayerResource(Player player)
    {
        return player.Gold;
    }
}
