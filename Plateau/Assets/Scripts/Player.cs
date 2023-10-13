using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mino;
using System;
using TMPro;

public class Player : MonoBehaviour
{
    private TableManager _tableManager;

    [SerializeField] private string playerName;

    private int _health;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int startHealth = 10;
    private int _gold;
    [SerializeField] private int maxGold = 20;
    [SerializeField] private int startGold = 5;

    [SerializeField] private HandArtifactDisplay handArtifactDisplayPrefab;
    private List<HandArtifactDisplay> _artifacts;
    [SerializeField] private int maximumArtifacts = 3;

    [SerializeField] private HandSpellDisplay handSpellDisplayPrefab;
    private List<HandSpellDisplay> _spells;
    [SerializeField] private int maximumSpells = 3;

    [SerializeField] private PlayerOverlay playerOverlay;

    private Tile _currentTile;

    public event Action<TableTurnStartState> OnTurnStart;

    public TableManager TableManager { get { return _tableManager; } }
    public string PlayerName { get { return playerName; } }
    public int Health { get { return _health; } }
    public int Gold { get { return _gold; } }
    public List<HandArtifactDisplay> Artifacts { get { return _artifacts; } }
    public int MaximumArtifacts { get { return maximumArtifacts; } }
    public List<HandSpellDisplay> Spells { get { return _spells; } }
    public int MaximumSpells { get { return maximumSpells; } }
    public Tile CurrentTile { get { return _currentTile; } }

    public void Initialize(TableManager tableManager, Tile startTile)
    {
        _tableManager = tableManager;

        playerOverlay.SetPlayerName(playerName);

        _artifacts = new();
        _spells = new();
        _currentTile = startTile;
        _currentTile.PlayersOnTheTile.Add(this);

        ResetStats();
    }

    public void StartTurn(TableTurnStartState state)
    {
        OnTurnStart?.Invoke(state);
    }

    public void ResetStats()
    {
        _health = startHealth;
        playerOverlay.SetHealthDisplay(_health);
        _gold = startGold;
        playerOverlay.SetgoldDisplay(_gold);
    }

    public void Move(int movementValue)
    {
        _currentTile.PlayersOnTheTile.Remove(this);

        for (int i = 0; i < movementValue; i++)
        {
            _currentTile = _currentTile.NextTile;
        }

        transform.position = _currentTile.transform.position;
        _currentTile.PlayersOnTheTile.Add(this);
    }

    public void MoveTo(Tile tile)
    {
        _currentTile = tile;
        transform.position = _currentTile.transform.position;
    }

    public void EarnGold(int amount)
    {
        _gold += amount;
        _gold = Mathf.Clamp(_gold, 0, maxGold);
        playerOverlay.SetgoldDisplay(_gold);
    }

    public void LoseGold(int amount)
    {
        _gold -= amount;
        _gold = Mathf.Clamp(_gold, 0, maxGold);
        playerOverlay.SetgoldDisplay(_gold);
    }

    public void Heal(int amount)
    {
        _health += amount;
        _health = Mathf.Clamp(_health, 0, maxHealth);
        playerOverlay.SetHealthDisplay(_health);
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        _health = Mathf.Clamp(_health, 0, maxHealth);
        playerOverlay.SetHealthDisplay(_health);

        if (_health == 0)
        {
            ResetStats();
            DiscardAllArtifacts();
            MoveTo(TableManager.Tiles[_tableManager.InnTileIndex]);
        }
    }

    public void Die()
    {
        TakeDamage(_health);
    }

    public void DrawArtifacts(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            PutArtifactInHand(_tableManager.ArtifactDeck.Draw());
        }
    }

    public void PutArtifactInHand(ArtifactData artifact)
    {
        if (artifact == null) return;

        HandArtifactDisplay newArtifact = Instantiate(handArtifactDisplayPrefab, playerOverlay.ArtifactsHand);
        newArtifact.Initialize(_tableManager, this);
        newArtifact.SetData(artifact);
        _artifacts.Add(newArtifact);
    }

    public void DiscardArtifact(HandArtifactDisplay artifact)
    {
        _tableManager.ArtifactDeck.PutInGraveyard(artifact.ArtifactData);
        _artifacts.Remove(artifact);
        Destroy(artifact.gameObject);
    }

    public void DiscardAllArtifacts()
    {
        foreach (ArtifactDisplay artifact in _artifacts)
        {
            _tableManager.ArtifactDeck.PutInGraveyard(artifact.ArtifactData);
            Destroy(artifact.gameObject);
        }

        _artifacts.Clear();
    }

    public void DrawSpells(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            PutSpellInHand(_tableManager.SpellDeck.Draw());
        }
    }

    public void PutSpellInHand(SpellData spell)
    {
        if (spell == null) return;

        HandSpellDisplay newSpell = Instantiate(handSpellDisplayPrefab, playerOverlay.SpellsHand);
        newSpell.Initialize(_tableManager, this);
        newSpell.SetData(spell);
        _spells.Add(newSpell);
    }

    public void DiscardSpell(HandSpellDisplay spell)
    {
        _tableManager.SpellDeck.PutInGraveyard(spell.SpellData);
        _spells.Remove(spell);
        Destroy(spell.gameObject);
    }
}