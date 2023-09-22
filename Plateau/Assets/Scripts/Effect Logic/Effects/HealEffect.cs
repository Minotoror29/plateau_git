using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : Effect
{
    private int _healthAmount;

    public HealEffect(TableManager tableManager, HealEffectData data) : base(tableManager)
    {
        _healthAmount = data.healthAmount;
    }

    public override void Activate()
    {
        TableManager.Player.Heal(_healthAmount);
        ResolveEffect();
    }
}
