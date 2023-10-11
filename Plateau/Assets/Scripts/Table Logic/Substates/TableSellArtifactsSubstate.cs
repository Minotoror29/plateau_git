using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSellArtifactsSubstate : TableSubstate
{
    private SellMerchandiseDisplay _display;
    private SellArtifactsEffect _effect;

    public TableSellArtifactsSubstate(TableManager tableManager, SellArtifactsEffect effect) : base(tableManager)
    {
        _display = TableManager.SellMerchandiseDisplay;
        _effect = effect;
    }

    public override void Enter()
    {
        _display.gameObject.SetActive(true);
        _display.Initialize(_effect, "artifact", 3);
    }

    public override void Exit()
    {
        _display.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
    }

    public override void SelectArtifact(HandArtifactDisplay artifact, Player player)
    {
        base.SelectArtifact(artifact, player);

        TableManager.CurrentPlayer.EarnGold(artifact.ArtifactData.goldValue);
        TableManager.CurrentPlayer.DiscardArtifact(artifact);
    }
}
