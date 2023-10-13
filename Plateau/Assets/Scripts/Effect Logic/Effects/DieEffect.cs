using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEffect : Effect
{
    private PlayerApplicationData _playerApplication;

    public DieEffect(TableManager tableManager, TileState state, string description, DieEffectData data) : base(tableManager, state, description)
    {
        _playerApplication = data.playerApplication;
    }

    public override void Activate()
    {
        foreach (Player player in _playerApplication.Players(TableManager))
        {
            player.Die();
        }

        ResolveEffect();
    }
}
