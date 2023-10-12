using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseAllGoldEffect : Effect
{
    public LoseAllGoldEffect(TableManager tableManager, TileState state, string description) : base(tableManager, state, description)
    {
    }

    public override void Activate()
    {
        TableManager.CurrentPlayer.LoseGold(TableManager.CurrentPlayer.Gold);
        ResolveEffect();
    }
}
