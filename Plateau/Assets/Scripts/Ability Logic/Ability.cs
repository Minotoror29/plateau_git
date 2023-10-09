using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability
{
    private TableManager _tableManager;
    private TileState _state;

    private string _description;

    public TableManager TableManager { get { return _tableManager; } }
    public TileState State { get { return _state; } }
    public string Description { get { return _description; } }

    public Ability(TableManager tableManager, TileState state, string description)
    {
        _tableManager = tableManager;
        _state = state;
        _description = description;
    }

    public abstract void Activate();

    public void ResolveAbility()
    {
        _state.ResolveAbility();
    }
}
