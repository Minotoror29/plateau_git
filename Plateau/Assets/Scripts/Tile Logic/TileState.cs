using Mino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileState : State
{
    private TableManager _tableManager;

    private Tile _tile;
    private TileFaceData _faceData;
    private int _faceIndex;

    private List<TileEffect> _effects;
    private int _resolvedEffects = 0;

    public TileState(TableManager tableManager, Tile tile, TileFaceData faceData, int faceIndex)
    {
        _tableManager = tableManager;

        _tile = tile;
        _faceData = faceData;
        _faceIndex = faceIndex;

        _effects = new();
        foreach (TileEffectData effect in faceData.effects)
        {
            _effects.Add(effect.Effect(tableManager, this));
        }
    }

    public override void Enter()
    {
        _tile.SpriteRenderer.color = _faceData.faceColor;
    }

    public override void UpdateLogic()
    {
    }

    public override void Exit()
    {
    }

    public void ActivateEffects(Player player)
    {
        _resolvedEffects = 0;

        foreach (TileEffect effect in _effects)
        {
            effect.Activate(player);
        }
    }

    public void ResolveEffect()
    {
        _resolvedEffects++;

        if (_resolvedEffects == _effects.Count)
        {
            _tableManager.ChangeState(new TableCheckState(_tableManager));
        }
    }

    public void FlipTile()
    {
        _tile.ChangeState(_tile.States[(_faceIndex + 1) % _tile.States.Length]);
    }
}
