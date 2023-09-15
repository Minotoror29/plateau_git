using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileEffect
{
    private TableManager _tableManager;

    public TableManager TableManager { get { return _tableManager; } }

    public TileEffect(TableManager tableManager)
    {
        _tableManager = tableManager;
    }

    public abstract void Activate(Player player);

    public void Resolve()
    {
        _tableManager.ChangeState(new TableTurnStartState(_tableManager));
    }
}
