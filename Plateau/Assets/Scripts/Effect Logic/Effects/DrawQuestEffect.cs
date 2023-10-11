using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawQuestEffect : Effect
{
    private int _questAmount;

    public DrawQuestEffect(TableManager tableManager, TileState state, string description, DrawQuestEffectData data) : base(tableManager, state, description)
    {
        _questAmount = data.questAmount;
    }

    public override void Activate()
    {
        TableManager.DrawQuests(_questAmount);
        
        if (TableManager.ActiveQuests.Count > TableManager.MaximumQuests)
        {
            TableManager.CurrentState.ChangeSubstate(new TableDiscardQuestSubstate(TableManager, TableManager.ActiveQuests.Count - TableManager.MaximumQuests, this));
        } else
        {
            ResolveEffect();
        }
    }
}
