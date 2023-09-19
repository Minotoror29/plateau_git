using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileEffect
{
    private TableManager _tableManager;

    private TileState _state;

    public TableManager TableManager { get { return _tableManager; } }

    public TileEffect(TableManager tableManager, TileState state)
    {
        _tableManager = tableManager;
        _state = state;
    }

    public abstract void Activate(Player player);

    public void Resolve()
    {
        _state.ResolveEffect();
    }
}
