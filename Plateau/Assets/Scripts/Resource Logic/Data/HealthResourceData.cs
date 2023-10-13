using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Resource/Health")]
public class HealthResourceData : ResourceData
{
    public override void LoseResource(Player player, int amount)
    {
        player.TakeDamage(amount);
    }

    public override int PlayerResource(Player player)
    {
        return player.Health;
    }
}
