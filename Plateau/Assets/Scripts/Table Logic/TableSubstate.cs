using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TableSubstate : State
{
    private TableManager _tableManager;

    private TableState _currentSuperState;

    public TableManager TableManager { get { return _tableManager; } }
    public TableState CurrentSuperstate { get { return _currentSuperState; } }

    public TableSubstate(TableManager tableManager)
    {
        _tableManager = tableManager;
    }

    public void SetSuperstate(TableState newSuperstate)
    {
        _currentSuperState = newSuperstate;
    }

    public virtual void SelectArtifact(HandArtifactDisplay artifact, Player player)
    {

    }

    public virtual void SelectSpell(HandSpellDisplay spell, Player player)
    {

    }

    public virtual void SelectQuest(QuestDisplay quest)
    {

    }
}
