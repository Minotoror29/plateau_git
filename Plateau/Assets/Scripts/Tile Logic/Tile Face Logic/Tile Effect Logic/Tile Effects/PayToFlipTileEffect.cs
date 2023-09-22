using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayToFlipTileEffect : TileEffect
{
    private int _goldAmount;

    public PayToFlipTileEffect(TableManager tableManager, TileState state, int goldAmount) : base(tableManager, state)
    {
        _goldAmount = goldAmount;
    }

    public override void Activate(Player player)
    {
        TableManager.PayAbilityDisplay.gameObject.SetActive(true);
        //TableManager.PayToFlipDisplay.Initialize(player, this, _goldAmount);
    }
}
