using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    [SerializeField] private Player player;

    private List<GameTile> _tiles;
    [SerializeField] private GameTileData tileData;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _tiles = new();

        for (int i = 0; i < transform.childCount; i++)
        {
            _tiles.Add(transform.GetChild(i).GetComponent<GameTile>());
        }

        foreach (GameTile tile in _tiles)
        {
            tile.Initialize(tileData, _tiles[(_tiles.IndexOf(tile) + 1) % _tiles.Count]);
        }

        player.Initialize(_tiles[0]);
    }

    public int TossDice()
    {
        return Random.Range(1, 7);
    }

    public void MovePlayer()
    {
        player.Move(TossDice());
    }
}
