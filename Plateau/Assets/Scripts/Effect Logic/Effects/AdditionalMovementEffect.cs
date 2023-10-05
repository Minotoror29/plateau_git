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
        //A revoir lorsque le système multijoueur ou le système de sorts seront ajoutés
        ResolveEffect();
    }
}
