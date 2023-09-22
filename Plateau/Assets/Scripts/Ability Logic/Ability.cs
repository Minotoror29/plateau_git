using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability
{
    private TableManager _tableManager;
    private TileState _state;

    public TableManager TableManager { get { return _tableManager; } }
    public TileState State { get { return _state; } }

    public Ability(TableManager tableManager, TileState state)
    {
        _tableManager = tableManager;
        _state = state;
    }

    public abstract void Activate(Player player);

    public void ResolveAbility()
    {
        _state.ResolveAbility();
    }
}
