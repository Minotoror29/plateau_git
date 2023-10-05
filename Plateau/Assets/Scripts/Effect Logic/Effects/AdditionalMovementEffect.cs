using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalMovementEffect : Effect
{
    public AdditionalMovementEffect(TableManager tableManager, TileState state, string description) : base(tableManager, state, description)
    {
    }

    public override void Activate()
    {
        //A revoir lorsque le syst�me multijoueur ou le syst�me de sorts seront ajout�s
        ResolveEffect();
    }
}
