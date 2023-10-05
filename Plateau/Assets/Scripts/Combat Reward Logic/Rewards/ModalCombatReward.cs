using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalCombatReward : CombatReward
{
    private int _goldAmount;
    private int _artifactAmount;

    private bool _hasChosenGold;

    public bool HasChosenGold { set { _hasChosenGold = value; } }

    public ModalCombatReward(TableManager tableManager, CombatEffect combat, ModalCombatRewardData data) : base(tableManager, combat)
    {
        _goldAmount = data.goldAmount;
        _artifactAmount = data.artifactAmount;
    }

    public override void DetermineReward()
    {
        TableManager.ModalCombatRewardDisplay.gameObject.SetActive(true);
        TableManager.ModalCombatRewardDisplay.Initialize(this, _goldAmount, _artifactAmount);
    }

    public override void EarnReward(Player player)
    {
        if (_hasChosenGold)
        {
            player.EarnGold(_goldAmount);
        } else
        {
            player.DrawArtifacts(_artifactAmount);
        }
    }
}
