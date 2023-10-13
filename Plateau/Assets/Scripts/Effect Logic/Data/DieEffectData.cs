using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Die")]
public class DieEffectData : EffectData
{
    public PlayerApplicationData playerApplication;

    public override Effect Effect(TableManager tableManager, TileState state)
    {
        return new DieEffect(tableManager, state, description, this);
    }
}
