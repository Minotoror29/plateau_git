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

    private Tile _currentTile;

    public event Action<TableTurnStartState> OnTurnStart;

    public TableManager TableManager { get { return _tableManager; } }
    public int Gold { get { return _gold; } }
    public Tile CurrentTile { get { return _currentTile; } }

    public void Initialize(TableManager tableManager, Tile startTile)
    {
        _tableManager = tableManager;

        _currentTile = startTile;

        _health = startHealth;
        SetHealthDisplay();
        _gold = startGold;
        SetGoldDisplay();
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
        Debug.Log("Player drew " + amount + " artifact(s)");
    }
}