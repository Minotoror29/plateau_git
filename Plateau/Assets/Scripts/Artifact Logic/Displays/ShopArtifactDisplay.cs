using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopArtifactDisplay : ArtifactDisplay, IPointerDownHandler
{
    private BuyMerchandiseDisplay _buyMerchandiseDisplay;

    public void Initialize(BuyMerchandiseDisplay buyMerchandiseDisplay)
    {
        _buyMerchandiseDisplay = buyMerchandiseDisplay;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _buyMerchandiseDisplay.BuyArtifact(this);
    }
}
