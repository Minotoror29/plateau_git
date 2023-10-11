using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandSpellDisplay : SpellDisplay, IPointerDownHandler
{
    private TableManager _tableManager;
    private Player _player;

    public void Initialize(TableManager tableManager, Player player)
    {
        _tableManager = tableManager;
        _player = player;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _tableManager.CurrentState.SelectSpell(this, _player);
    }
}
