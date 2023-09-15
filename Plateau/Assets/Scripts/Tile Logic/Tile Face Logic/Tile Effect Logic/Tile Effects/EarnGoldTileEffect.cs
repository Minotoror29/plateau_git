using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnGoldTileEffect : TileEffect
{
    private int _goldAmount;

    public EarnGoldTileEffect(TableManager tableManager, EarnGoldTileEffectData data) : base(tableManager)
    {
        _goldAmount = data.goldAmount;
    }

    public override void Activate(Player player)
    {
        player.EarnGold(_goldAmount);

        Resolve();
    }
}
