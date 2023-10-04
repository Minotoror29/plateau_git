using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandArtifactDisplay : ArtifactDisplay, IPointerDownHandler
{
    private TableManager _tableManager;

    public void Initialize(TableManager tableManager)
    {
        _tableManager = tableManager;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _tableManager.CurrentState.SelectArtifact(this);
    }
}
