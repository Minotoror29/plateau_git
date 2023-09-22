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

    private List<Ability> _abilities;
    private int _resolvedEffects = 0;

    public TileState(TableManager tableManager, Tile tile, TileFaceData faceData, int faceIndex)
    {
        _tableManager = tableManager;

        _tile = tile;
        _faceData = faceData;
        _faceIndex = faceIndex;

        _abilities = new();
        foreach (AbilityData ability in faceData.abilities)
        {
            _abilities.Add(ability.Ability(tableManager, this));
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

        foreach (Ability ability in _abilities)
        {
            ability.Activate(player);
        }
    }

    public void ResolveEffect()
    {
        _resolvedEffects++;

        if (_resolvedEffects == _abilities.Count)
        {
            _tableManager.ChangeState(new TableCheckState(_tableManager));
        }
    }

    public void FlipTile()
    {
        _tile.ChangeState(_tile.States[(_faceIndex + 1) % _tile.States.Length]);
    }
}
