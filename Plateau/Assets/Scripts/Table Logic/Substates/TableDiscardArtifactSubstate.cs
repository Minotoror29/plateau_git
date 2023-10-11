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
        TableManager.DiscardMerchandiseDisplay.Initialize(TableManager.CurrentPlayer.PlayerName, "artifact");
    }

    public override void SelectArtifact(HandArtifactDisplay artifact, Player player)
    {
        base.SelectArtifact(artifact, player);

        if (player != TableManager.CurrentPlayer) return;

        TableManager.CurrentPlayer.DiscardArtifact(artifact);
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
