using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableDiscardArtifactSubstate : TableSubstate
{
    private int _artifactsToDiscard;
    private Effect _effect;

    public TableDiscardArtifactSubstate(TableManager tableManager, int artifactsToDiscard, Effect effect) : base(tableManager)
    {
        _artifactsToDiscard = artifactsToDiscard;
        _effect = effect;
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
            _effect.ResolveEffect();
            CurrentSuperstate.ChangeSubstate(new TableDefaultSubstate(TableManager));
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
