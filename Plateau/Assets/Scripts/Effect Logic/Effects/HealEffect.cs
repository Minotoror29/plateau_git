using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : Effect
{
    private int _healthAmount;

    public HealEffect(TableManager tableManager, TileState state, HealEffectData data, string description) : base(tableManager, state, description)
    {
        _healthAmount = data.healthAmount;
    }

    public override void Activate()
    {
        TableManager.CurrentPlayer.Heal(_healthAmount);
        ResolveEffect();
    }
}
