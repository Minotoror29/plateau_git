using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalAbility : Ability
{
    private Ability _ability1;
    private Ability _ability2;

    public ModalAbility(TableManager tableManager, TileState state, string description, ModalAbilityData data) : base(tableManager, state, description)
    {
        _ability1 = data.ability1.Ability(TableManager, state);
        _ability2 = data.ability2.Ability(TableManager, state);
    }

    public override void Activate()
    {
        TableManager.ModalAbilityDisplay.gameObject.SetActive(true);
        TableManager.ModalAbilityDisplay.Initialize(_ability1, _ability2);
    }
}
