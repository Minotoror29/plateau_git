using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTileEffect : TileEffect
{
    private int _healthAmount;

    public HealTileEffect(TableManager tableManager, TileState state, HealTileEffectData data) : base(tableManager, state)
    {
        _healthAmount = data.healthAmount;
    }

    public override void Activate(Player player)
    {
        player.Heal(_healthAmount);

        Resolve();
    }
}
