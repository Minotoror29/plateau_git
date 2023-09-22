using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PayXAbilityDisplay : MonoBehaviour
{
    private Player _player;
    private PayXAbility _ability;
    private int _goldAmount;

    [SerializeField] private List<TextMeshProUGUI> amountDisplays;

    public void Initialize(Player player, PayXAbility ability)
    {
        _player = player;
        _ability = ability;

        _goldAmount = 0;
        SetAmounts();
    }

    public void Increase()
    {
        _goldAmount++;
        SetAmounts();
    }

    public void Decrease()
    {
        _goldAmount--;
        SetAmounts();
    }

    public void SetAmounts()
    {
        _goldAmount = Mathf.Clamp(_goldAmount, 0, _player.Gold);

        foreach (TextMeshProUGUI display in amountDisplays)
        {
            display.text = _goldAmount.ToString();
        }
    }

    public void Accept()
    {
        gameObject.SetActive(false);
        _ability.ActivateEffects(_goldAmount);
    }

    public void Decline()
    {
        gameObject.SetActive(false);
        _ability.ResolveAbility();
    }
}
