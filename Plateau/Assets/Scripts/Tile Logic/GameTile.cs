using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour
{
    private GameTileData _data;
    private string _tileName;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private GameTile _nextTile;

    public GameTile NextTile { get { return _nextTile; } }

    public void Initialize(GameTileData data, GameTile nextTile)
    {
        _data = data;
        _tileName = data.tileName;
        spriteRenderer.color = data.tileColor;

        _nextTile = nextTile;
    }

    public void ActivateEffect(Player player)
    {
        _data.effect.Activate(player);
    }
}
