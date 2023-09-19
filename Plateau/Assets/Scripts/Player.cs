using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mino;
using System;

public class Player : MonoBehaviour
{
    private TableManager _tableManager;

    private int _health;
    [SerializeField] private int maxHealth = 10;
    private int _gold;
    [SerializeField] private int maxGold = 20;
    [SerializeField] private int startGold = 5;

    private Tile _currentTile;

    public event Action<TableTurnStartState> OnTurnStart;

    public TableManager TableManager { get { return _tableManager; } }
    public Tile CurrentTile { get { return _currentTile; } }

    public void Initialize(TableManager tableManager, Tile startTile)
    {
        _tableManager = tableManager;

        _currentTile = startTile;

        _health = maxHealth;
        _gold = startGold;
    }

    public void StartTurn(TableTurnStartState state)
    {
        OnTurnStart?.Invoke(state);
    }

    public void Move(int movementValue)
    {
        for (int i = 0; i < movementValue; i++)
        {
            _currentTile = _currentTile.NextTile;
        }

        transform.position = _currentTile.transform.position;
    }

    public void EarnGold(int amount)
    {
        _gold += amount;
        _gold = Mathf.Clamp(_gold, 0, maxGold);

        Debug.Log("Player earned " + amount + " gold");
    }

    public void LoseGold(int amount)
    {
        _gold -= amount;
        _gold = Mathf.Clamp(_gold, 0, maxGold);

        Debug.Log("Player lost " + amount + " gold");
    }

    public void Heal(int amount)
    {
        _health += amount;
        _health = Mathf.Clamp(_health, 0, maxHealth);

        Debug.Log("Player was healed " + amount + " HP");
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        _health = Mathf.Clamp(_health, 0, maxHealth);

        Debug.Log("Player lost " + amount + " HP");
    }

    public void DrawArtifact(int amount)
    {
        Debug.Log("Player drew " + amount + " artifact(s)");
    }
}