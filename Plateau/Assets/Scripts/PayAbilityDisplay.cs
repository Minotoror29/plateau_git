using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PayAbilityDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;

    private Player _player;
    private PayAbility _ability;
    private ResourceData _resource;
    private int _amount;

    public void Initialize(Player player, PayAbility ability, ResourceData resource, int amount)
    {
        _player = player;
        _ability = ability;
        _resource = resource;
        _amount = amount;

        title.text = _ability.Description;
    }

    public void Accept()
    {
        if (_resource.PlayerResource(_player) >= _amount)
        {
            gameObject.SetActive(false);
            _ability.ActivateEffects();
        }
    }

    public void Decline()
    {
        gameObject.SetActive(false);
        _ability.ResolveAbility();
    }
}
