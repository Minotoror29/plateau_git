using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Lose All Artifacts")]
public class LoseAllArtifactsEffectData : EffectData
{
    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new LoseAllArtifactsEffect(tableManager, state, description);
    }
}
