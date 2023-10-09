using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyArtifactsEffect : Effect
{
    private int _artifactsToReveal;
    private int _artifactsToBuy;

    public BuyArtifactsEffect(TableManager tableManager, TileState state, string description, int merchandiseToReveal, int merchandiseToBuy) : base(tableManager, state, description)
    {
        _artifactsToReveal = merchandiseToReveal;
        _artifactsToBuy = merchandiseToBuy;
    }

    public override void Activate()
    {
        TableManager.BuyArtifactsDisplay.gameObject.SetActive(true);
        TableManager.BuyArtifactsDisplay.SetEffect(this);
        TableManager.BuyArtifactsDisplay.SetArtifacts(_artifactsToReveal, _artifactsToBuy);
    }

    public void Confirm(int boughtArtifacts)
    {
        TableManager.BuyArtifactsDisplay.gameObject.SetActive(false);

        if (boughtArtifacts >= _artifactsToBuy)
        {
            State.FlipTile();
        }

        if (TableManager.Player.Artifacts.Count > TableManager.Player.MaximumArtifacts)
        {
            TableManager.CurrentState.ChangeSubstate(new TableDiscardArtifactSubstate(TableManager, TableManager.Player.Artifacts.Count - TableManager.Player.MaximumArtifacts, this));
        }
        else
        {
            ResolveEffect();
        }
    }
}
