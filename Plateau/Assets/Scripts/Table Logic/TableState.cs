using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TableState : State
{
    private TableManager _tableManager;

    private TableSubstate _currentSubstate;

    public TableManager TableManager { get { return _tableManager; } }
    public TableSubstate CurrentSubstate { get { return _currentSubstate; } }

    public TableState(TableManager tableManager, TableSubstate subState)
    {
        _tableManager = tableManager;

        ChangeSubstate(subState);
    }

    public void ChangeSubstate(TableSubstate newSubstate)
    {
        _currentSubstate?.Exit();
        _currentSubstate = newSubstate;
        _currentSubstate.SetSuperstate(this);
        _currentSubstate.Enter();
    }

    public virtual void SelectArtifact(ArtifactDisplay artifact)
    {
        //_currentSubstate?.SelectArtifact(artifact);
    }
}
