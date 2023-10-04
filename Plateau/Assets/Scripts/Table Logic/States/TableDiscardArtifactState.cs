using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableDiscardArtifactState : TableState
{
    private int _artifactsToDiscard;

    public TableDiscardArtifactState(TableManager tableManager, TableSubstate subState, int artifactsToDiscard) : base(tableManager, subState)
    {
        _artifactsToDiscard = artifactsToDiscard;
    }

    public override void Enter()
    {
        TableManager.DiscardMerchandiseDisplay.gameObject.SetActive(true);
        TableManager.DiscardMerchandiseDisplay.Initialize("artifact");
    }

    public override void SelectArtifact(ArtifactDisplay artifact)
    {
        base.SelectArtifact(artifact);

        TableManager.Player.DiscardArtifact(artifact);
        _artifactsToDiscard--;

        if (_artifactsToDiscard == 0)
        {
            TableManager.ChangeState(new TableTurnStartState(TableManager, CurrentSubstate));
        }
    }

    public override void Exit()
    {
        TableManager.DiscardMerchandiseDisplay.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
    }
}
