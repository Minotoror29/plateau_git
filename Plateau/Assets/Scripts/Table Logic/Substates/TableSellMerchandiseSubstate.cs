using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSellMerchandiseSubstate : TableSubstate
{
    private SellMerchandiseDisplay _display;
    private SellEffect _effect;

    public TableSellMerchandiseSubstate(TableManager tableManager, SellEffect effect) : base(tableManager)
    {
        _display = TableManager.SellMerchandiseDisplay;
        _effect = effect;
    }

    public override void Enter()
    {
        _display.gameObject.SetActive(true);
        _display.Initialize(_effect);
    }

    public override void Exit()
    {
        _display.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
    }

    public override void SelectArtifact(HandArtifactDisplay artifact)
    {
        base.SelectArtifact(artifact);

        TableManager.Player.EarnGold(artifact.ArtifactData.goldValue);
        TableManager.Player.DiscardArtifact(artifact);
    }
}
