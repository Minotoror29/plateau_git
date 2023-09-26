using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TableState : State
{
    private TableManager _tableManager;

    public TableManager TableManager { get { return _tableManager; } }

    public TableState(TableManager tableManager)
    {
        _tableManager = tableManager;
    }

    public virtual void SelectArtifact(ArtifactDisplay artifact)
    {

    }
}
