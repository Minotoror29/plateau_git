using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mino;
using System;
using TMPro;

public class Player : MonoBehaviour
{
    private TableManager _tableManager;

    private int _health;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int startHealth = 10;
    [SerializeField] private TextMeshProUGUI healthDisplay;
    private int _gold;
    [SerializeField] private int maxGold = 20;
    [SerializeField] private int startGold = 5;
    [SerializeField] private TextMeshProUGUI goldDisplay;

    [SerializeField] private Transform artifactsParent;
    [SerializeField] private HandArtifactDisplay handArtifactDisplayPrefab;
    private List<HandArtifactDisplay> _artifacts;
    [SerializeField] private int maximumArtifacts = 3;

    private Tile _currentTile;

    public event Action<TableTurnStartState> OnTurnStart;

    public TableManager TableManager { get { return _tableManager; } }
    public int Health { get { return _health; } }
    public int Gold { get { return _gold; } }
    public List<HandArtifactDisplay> Artifacts { get { return _artifacts; } }
    public int MaximumArtifacts { get { return maximumArtifacts; } }
    public Tile CurrentTile { get { return _currentTile; } }

    public void Initialize(TableManager tableManager, Tile startTile)
    {
        _tableManager = tableManager;

        _artifacts = new();
        _currentTile = startTile;

        ResetStats();
    }

    public void StartTurn(TableTurnStartState state)
    {
        OnTurnStart?.Invoke(state);
    }

    public void ResetStats()
    {
        _health = startHealth;
        SetHealthDisplay();
        _gold = startGold;
        SetGoldDisplay();
    }

    public void Move(int movementValue)
    {
        for (int i = 0; i < movementValue; i++)
        {
            _currentTile = _currentTile.NextTile;
        }

        transform.position = _currentTile.transform.position;
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
        SetGoldDisplay();
    }

    public void LoseGold(int amount)
    {
        _gold -= amount;
        _gold = Mathf.Clamp(_gold, 0, maxGold);
        SetGoldDisplay();
    }

    private void SetGoldDisplay()
    {
        goldDisplay.text = "Gold : " + _gold.ToString();
    }

    public void Heal(int amount)
    {
        _health += amount;
        _health = Mathf.Clamp(_health, 0, maxHealth);
        SetHealthDisplay();
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        _health = Mathf.Clamp(_health, 0, maxHealth);
        SetHealthDisplay();
    }

    private void SetHealthDisplay()
    {
        healthDisplay.text = "HP : " + _health;
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

        HandArtifactDisplay newArtifact = Instantiate(handArtifactDisplayPrefab, artifactsParent);
        newArtifact.Initialize(_tableManager);
        newArtifact.SetData(artifact);
        _artifacts.Add(newArtifact);
    }

    public void DiscardArtifact(HandArtifactDisplay artifact)
    {
        _tableManager.ArtifactDeck.PutInGraveyard(artifact.ArtifactData);
        _artifacts.Remove(artifact);
        Destroy(artifact.gameObject);
    }
}