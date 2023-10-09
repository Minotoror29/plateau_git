using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopSpellDisplay : SpellDisplay, IPointerDownHandler
{
    private BuySpellsDisplay _buyMerchandiseDisplay;

    public void Initialize(BuySpellsDisplay buyMerchandiseDisplay)
    {
        _buyMerchandiseDisplay = buyMerchandiseDisplay;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _buyMerchandiseDisplay.BuySpell(this);
    }
}
