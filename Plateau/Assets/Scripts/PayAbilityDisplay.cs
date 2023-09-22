using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PayAbilityDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;

    private Player _player;
    private PayAbility _ability;
    private int _goldAmount;

    public void Initialize(Player player, PayAbility ability, int goldAmount)
    {
        _player = player;
        _ability = ability;
        _goldAmount = goldAmount;

        string effectsDescriptions = "";

        for (int i = 0; i < _ability.Effects.Count; i++)
        {
            if (i == 0)
            {
                effectsDescriptions += (" " + _ability.Effects[i].Description);
            } else
            {
                effectsDescriptions += (", " + _ability.Effects[i].Description);
            }
        }

        title.text = "PAY " + goldAmount.ToString() + " TO " + effectsDescriptions + " ?";
    }

    public void Accept()
    {
        if (_player.Gold >= _goldAmount)
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
