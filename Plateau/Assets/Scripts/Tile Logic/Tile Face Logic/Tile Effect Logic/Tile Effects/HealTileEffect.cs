using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTileEffect : TileEffect
{
    private int _healthAmount;

    public HealTileEffect(TableManager tableManager, HealTileEffectData data) : base(tableManager)
    {
        _healthAmount = data.healthAmount;
    }

    public override void Activate(Player player)
    {
        player.Heal(_healthAmount);

        Resolve();
    }
}
