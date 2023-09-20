using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTileEffect : TileEffect
{
    private ValueApplication _healthAmount;

    public HealTileEffect(TableManager tableManager, TileState state, HealTileEffectData data) : base(tableManager, state)
    {
        _healthAmount = data.healthAmount.Value(tableManager);
    }

    public override void Activate(Player player)
    {
        _healthAmount.OnResolution += Heal;
        _healthAmount.DetermineValue();
    }

    public void Heal()
    {
        _healthAmount.OnResolution -= Heal;
        TableManager.Player.Heal(_healthAmount.Value);
        Resolve();
    }
}
