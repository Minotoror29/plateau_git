using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableDiscardQuestSubstate : TableSubstate
{
    private int _questsToDiscard;
    private Effect _effect;

    public TableDiscardQuestSubstate(TableManager tableManager, int questsToDiscard, Effect effect) : base(tableManager)
    {
        _questsToDiscard = questsToDiscard;
        _effect = effect;
    }

    public override void Enter()
    {
        TableManager.DiscardQuestsDisplay.gameObject.SetActive(true);
        TableManager.DiscardQuestsDisplay.Initialize(TableManager.CurrentPlayer.PlayerName);
    }

    public override void Exit()
    {
        TableManager.DiscardQuestsDisplay.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
    }

    public override void SelectQuest(QuestDisplay quest)
    {
        base.SelectQuest(quest);

        TableManager.DiscardQuest(quest);
        _questsToDiscard--;

        if (_questsToDiscard == 0)
        {
            TableManager.CurrentState.ChangeSubstate(new TableDefaultSubstate(TableManager));
            _effect.ResolveEffect();
        }
    }
}
