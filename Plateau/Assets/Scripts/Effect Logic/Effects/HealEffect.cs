using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : Effect
{
    private int _healthAmount;

    public HealEffect(TableManager tableManager, HealEffectData data, string description) : base(tableManager, description)
    {
        _healthAmount = data.healthAmount;
    }

    public override void Activate()
    {
        TableManager.Player.Heal(_healthAmount);
        ResolveEffect();
    }
}
