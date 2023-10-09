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

    private Deck<ArtifactData> _artifactDeck;
    private Deck<SpellData> _spellDeck;
    [SerializeField] private DiscardMerchandiseDisplay discardMerchandiseDisplay;

    [SerializeField] private ModalCombatRewardDisplay modalCombatRewardDisplay;
    [SerializeField] private PayAbilityDisplay payAbilityDisplay;
    [SerializeField] private PayXAbilityDisplay payXAbilityDisplay;
    [SerializeField] private BuyMerchandiseDisplay buyMerchandiseDisplay;
    [SerializeField] private SellMerchandiseDisplay sellMerchandiseDisplay;
    [SerializeField] private ModalAbilityDisplay modalAbilityDisplay;

    public TableState CurrentState { get { return _currentState; } }
    public Player Player { get { return player; } }
    public Boss Boss { get { return boss; } }
    public List<Tile> Tiles { get { return _tiles; } }
    public int InnTileIndex { get { return innTileIndex; } }
    public Button MoveButton { get { return moveButton; } }
    public Deck<ArtifactData> ArtifactDeck { get { return _artifactDeck; } }
    public Deck<SpellData> SpellDeck { get { return _spellDeck; } }
    public DiscardMerchandiseDisplay DiscardMerchandiseDisplay { get { return discardMerchandiseDisplay; } }
    public ModalCombatRewardDisplay ModalCombatRewardDisplay { get { return modalCombatRewardDisplay; } }
    public PayAbilityDisplay PayAbilityDisplay { get { return payAbilityDisplay; } }
    public PayXAbilityDisplay PayXAbilityDisplay { get { return payXAbilityDisplay; } }
    public BuyMerchandiseDisplay BuyMerchandiseDisplay { get { return buyMerchandiseDisplay; } }
    public SellMerchandiseDisplay SellMerchandiseDisplay { get { return sellMerchandiseDisplay; } }
    public ModalAbilityDisplay ModalAbilityDisplay { get { return modalAbilityDisplay; } }

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

        _artifactDeck = new Deck<ArtifactData>();
        _artifactDeck.FillDeck(Resources.LoadAll<ArtifactData>("Data/Artifacts"));

        _spellDeck = new Deck<SpellData>();
        _spellDeck.FillDeck(Resources.LoadAll<SpellData>("Data/Spells"));

        buyMerchandiseDisplay.Initialize(this);

        ChangeState(new TableTurnStartState(this, new TableDefaultSubstate(this)));
    }

    public void ChangeState(TableState nextState)
    {
        _currentState?.Exit();
        _currentState = nextState;
        _currentState.Enter();
    }

    public int TossDice()
    {
        int value = Random.Range(1, 7);
        Debug.Log("Dice Roll : " + value);
        return value;
    }
}
