using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mino;

public class Player : MonoBehaviour
{
    private int _health;
    [SerializeField] private int maxHealth = 10;
    private int _gold;
    [SerializeField] private int maxGold = 20;
    [SerializeField] private int startGold = 5;

    private Tile _currentTile;

    public Tile CurrentTile { get { return _currentTile; } }

    public void Initialize(Tile startTile)
    {
        _currentTile = startTile;

        _health = maxHealth;
        _gold = startGold;
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
    }
}