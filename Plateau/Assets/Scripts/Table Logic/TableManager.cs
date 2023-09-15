using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mino;
using UnityEngine.UI;

public class TableManager : MonoBehaviour
{
    private TableState _currentState;

    [SerializeField] private Player player;
    [SerializeField] private Boss boss;

    private List<Tile> _tiles;
    [SerializeField] private TileData tileData;

    [SerializeField] private TileData innTileData;
    [SerializeField] private int innTileIndex;
    [SerializeField] private TileData bossTileData;
    [SerializeField] private int bossTileIndex;

    [SerializeField] private Button moveButton;

    [SerializeField] private List<ArtifactData> artifacts;

    [SerializeField] private ModalCombatRewardDisplay modalCombatRewardDisplay;

    public Player Player { get { return player; } }
    public Boss Boss { get { return boss; } }
    public Button MoveButton { get { return moveButton; } }
    public ModalCombatRewardDisplay ModalCombatRewardDisplay { get { return modalCombatRewardDisplay; } }

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _tiles = new();

        for (int i = 0; i < transform.childCount; i++)
        {
            _tiles.Add(transform.GetChild(i).GetComponent<Tile>());
        }

        foreach (Tile tile in _tiles)
        {
            tile.Initialize(this, tileData, _tiles[(_tiles.IndexOf(tile) + 1) % _tiles.Count]);
        }

        for (int i = 0; i < _tiles.Count; i++)
        {
            if (i == innTileIndex)
            {
                _tiles[i].Initialize(this, innTileData, _tiles[(i + 1) % _tiles.Count]);
            } else if (i == bossTileIndex)
            {
                _tiles[i].Initialize(this, bossTileData, _tiles[(i + 1) % _tiles.Count]);
            } else
            {
                _tiles[i].Initialize(this, tileData, _tiles[(i + 1) % _tiles.Count]);
            }
        }

        player.Initialize(this, _tiles[0]);
        boss.Initialize();

        ChangeState(new TableTurnStartState(this));
    }

    public void ChangeState(TableState nextState)
    {
        _currentState?.Exit();
        _currentState = nextState;
        _currentState.Enter();
    }

    public int TossDice()
    {
        return Random.Range(1, 7);
    }

    public ArtifactData DrawArtifact()
    {
        return artifacts[0];
    }
}
