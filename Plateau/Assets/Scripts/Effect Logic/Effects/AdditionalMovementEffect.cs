using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalMovementEffect : Effect
{
    public AdditionalMovementEffect(TableManager tableManager, AdditionalMovementEffectData data) : base(tableManager, data)
    {
    }

    public override void Activate()
    {
        //A revoir lorsque le système multijoueur ou le système de sorts seront ajoutés
        ResolveEffect();
    }
}
