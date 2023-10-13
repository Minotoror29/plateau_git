using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceAbility : Ability
{
    private Ability _ability;

    private event Action OnAccept;
    private event Action OnDecline;

    public ChoiceAbility(TableManager tableManager, TileState state, string description, ChoiceAbilityData data) : base(tableManager, state, description)
    {
        _ability = data.ability.Ability(TableManager, state);

        OnAccept += Accept;
        OnDecline += Decline;
    }

    public override void Activate()
    {
        TableManager.PayAbilityDisplay.gameObject.SetActive(true);
        TableManager.PayAbilityDisplay.Initialize(this, OnAccept, OnDecline);
    }

    private void Accept()
    {
        TableManager.PayAbilityDisplay.UnsubscribeActions(OnAccept, OnDecline);
        TableManager.PayAbilityDisplay.gameObject.SetActive(false);
        _ability.Activate();
    }

    private void Decline()
    {
        TableManager.PayAbilityDisplay.UnsubscribeActions(OnAccept, OnDecline);
        TableManager.PayAbilityDisplay.gameObject.SetActive(false);
        ResolveAbility();
    }
}
