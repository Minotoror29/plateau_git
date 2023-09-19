using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalMovementTileEffect : TileEffect
{
    public AdditionalMovementTileEffect(TableManager tableManager) : base(tableManager)
    {
    }

    public override void Activate(Player player)
    {
        //A revoir lorsque le système multijoueur ou le système de sorts seront ajoutés
        Resolve();
    }
}
