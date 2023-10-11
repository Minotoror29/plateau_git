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

    public void SelectArtifact(HandArtifactDisplay artifact, Player player)
    {
        _currentSubstate?.SelectArtifact(artifact, player);
    }

    public void SelectSpell(HandSpellDisplay spell, Player player)
    {
        _currentSubstate?.SelectSpell(spell, player);
    }

    public void SelectQuest(QuestDisplay quest)
    {
        _currentSubstate?.SelectQuest(quest);
    }
}
