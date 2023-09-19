using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalMovementTileEffect : TileEffect
{
    public AdditionalMovementTileEffect(TableManager tableManager, TileState state) : base(tableManager, state)
    {
    }

    public override void Activate(Player player)
    {
        //A revoir lorsque le syst�me multijoueur ou le syst�me de sorts seront ajout�s
        Resolve();
    }
}
