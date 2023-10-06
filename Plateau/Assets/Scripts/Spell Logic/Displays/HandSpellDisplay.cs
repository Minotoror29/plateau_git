using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandSpellDisplay : SpellDisplay, IPointerDownHandler
{
    private TableManager _tableManager;

    public void Initialize(TableManager tableManager)
    {
        _tableManager = tableManager;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _tableManager.CurrentState.SelectSpell(this);
    }
}
