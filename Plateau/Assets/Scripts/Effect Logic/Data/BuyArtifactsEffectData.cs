using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Buy Artifacts")]
public class BuyArtifactsEffectData : EffectData
{
    public int artifactsToReveal;
    public int artifactsToBuy;

    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new BuyArtifactsEffect(tableManager, state, description, artifactsToReveal, artifactsToBuy);
    }
}
