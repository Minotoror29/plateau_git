using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopArtifactDisplay : ArtifactDisplay, IPointerDownHandler
{
    private BuyArtifactsDisplay _buyMerchandiseDisplay;

    public void Initialize(BuyArtifactsDisplay buyMerchandiseDisplay)
    {
        _buyMerchandiseDisplay = buyMerchandiseDisplay;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _buyMerchandiseDisplay.BuyArtifact(this);
    }
}
