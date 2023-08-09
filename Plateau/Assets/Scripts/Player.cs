using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mino;

public class Player : MonoBehaviour
{
    private int _health;
    [SerializeField] private int maximumHealth = 10;
    private int _gold;
    [SerializeField] private int maximumGold = 20;
    [SerializeField] private int startGold = 5;

    private Tile _currentTile;

    public void Initialize(Tile startTile)
    {
        _currentTile = startTile;

        _health = maximumHealth;
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
        _gold = Mathf.Clamp(_gold, 0, maximumGold);

        Debug.Log("Player earned " + amount + " gold");
    }

    public void Heal(int amount)
    {
        _health += amount;

        Debug.Log("Player was healed " + amount + " HP");
    }
}