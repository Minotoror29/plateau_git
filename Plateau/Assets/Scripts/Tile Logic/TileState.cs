using Mino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileState : State
{
    private Tile _tile;
    private TileFaceData _faceData;
    private int _faceIndex;

    public TileState(Tile tile, TileFaceData faceData, int faceIndex)
    {
        _tile = tile;
        _faceData = faceData;
        _faceIndex = faceIndex;
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

    public void ActivateEffect(TableManager tableManager, Player player)
    {
        _faceData.effect.Activate(tableManager, player);
    }
}
