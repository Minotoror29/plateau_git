using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SellMerchandiseDisplay : MonoBehaviour
{
    private SellEffect _effect;
    [SerializeField] private TextMeshProUGUI title;

    public void Initialize(SellEffect effect, string merchandise, int amount)
    {
        _effect = effect;
        title.text = "Choose up to " + amount.ToString() + " " + merchandise + "(s) to sell";
    }

    public void Confirm()
    {
        _effect.Confirm();
    }
}
