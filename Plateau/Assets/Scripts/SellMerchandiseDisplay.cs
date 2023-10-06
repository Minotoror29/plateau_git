using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellMerchandiseDisplay : MonoBehaviour
{
    private SellEffect _effect;

    public void Initialize(SellEffect effect)
    {
        _effect = effect;
    }

    public void Confirm()
    {
        _effect.Confirm();
    }
}
