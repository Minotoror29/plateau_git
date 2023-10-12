using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Teleportation")]
public class TeleportationEffectData : EffectData
{
    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new TeleportationEffect(tableManager, state, description);
    }
}
