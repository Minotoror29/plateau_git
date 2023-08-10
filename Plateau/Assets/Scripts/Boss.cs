using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private int _health;
    [SerializeField] private int maxHealth = 50;
    [SerializeField] private TextMeshProUGUI healthDisplay;

    public int Health { get { return _health; } }

    public void Initialize()
    {
        _health = maxHealth;
        healthDisplay.text = "Boss HP : " + _health;
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        _health = Mathf.Clamp(_health, 0, maxHealth);

        healthDisplay.text = "Boss HP : " + _health;
    }
}
