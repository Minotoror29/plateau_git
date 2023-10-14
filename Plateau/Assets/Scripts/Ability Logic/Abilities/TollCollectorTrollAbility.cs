using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TollCollectorTrollAbility : Ability
{
    private int _goldAmount;

    private event Action OnAccept;
    private event Action OnDecline;

    public TollCollectorTrollAbility(TableManager tableManager, TileState state, string description) : base(tableManager, state, description)
    {
        OnAccept += Accept;
        OnDecline += Decline;
    }

    public override void Activate()
    {
        _goldAmount = TableManager.TossDice();

        TableManager.PayAbilityDisplay.gameObject.SetActive(true);
        TableManager.PayAbilityDisplay.Initialize("Pay " + _goldAmount + " gold? If you don't flip the tile and fight the Angry Troll.", OnAccept, OnDecline);
    }

    private void Accept()
    {
        if (TableManager.CurrentPlayer.Gold < _goldAmount) return;

        TableManager.PayAbilityDisplay.UnsubscribeActions(OnAccept, OnDecline);
        TableManager.PayAbilityDisplay.gameObject.SetActive(false);

        TableManager.CurrentPlayer.LoseGold(_goldAmount);

        ResolveAbility();
    }

    private void Decline()
    {
        TableManager.PayAbilityDisplay.UnsubscribeActions(OnAccept, OnDecline);
        TableManager.PayAbilityDisplay.gameObject.SetActive(false);

        State.FlipTile();
        TableManager.ChangeState(new TableTileAbilityState(TableManager, TableManager.CurrentState.CurrentSubstate));
    }
}
