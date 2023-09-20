using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PayCustomGoldDisplay : MonoBehaviour
{
    private Player _player;
    private GoldValueApplication _valueApplication;
    private int _goldAmount;

    [SerializeField] private List<TextMeshProUGUI> amountDisplays;

    public void Initialize(Player player, GoldValueApplication valueApplication)
    {
        _player = player;
        _valueApplication = valueApplication;

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
        _player.LoseGold(_goldAmount);
        _valueApplication.Value = _goldAmount;
        _valueApplication.Resolve();
    }

    public void Decline()
    {
        gameObject.SetActive(false);
        _valueApplication.Value = 0;
        _valueApplication.Resolve();
    }
}
