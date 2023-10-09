using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Sell Artifacts")]
public class SellArtifactsEffectData : EffectData
{
    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new SellArtifactsEffect(tableManager, state, description);
    }
}
