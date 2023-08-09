using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _healthPoints;
    [SerializeField] private int maximumHealth = 10;
    public int _gold;
    [SerializeField] private int maximumGold = 20;
    [SerializeField] private int startGold = 5;

    private GameTile _currentTile;

    public void Initialize(GameTile startTile)
    {
        _currentTile = startTile;

        _healthPoints = maximumHealth;
        _gold = startGold;
    }

    public void Move(int movementValue)
    {
        for (int i = 0; i < movementValue; i++)
        {
            _currentTile = _currentTile.NextTile;
        }

        transform.position = _currentTile.transform.position;

        _currentTile.ActivateEffect(this);
    }

    public void EarnGold(int amount)
    {
        _gold += amount;
    }
}