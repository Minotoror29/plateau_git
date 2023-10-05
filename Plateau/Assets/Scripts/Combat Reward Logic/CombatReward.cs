using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatReward
{
    private TableManager _tableManager;
    private CombatEffect _combat;

    public TableManager TableManager { get { return _tableManager; } }
    public CombatEffect Combat { get { return _combat; } }

    public CombatReward(TableManager tableManager, CombatEffect combat)
    {
        _tableManager = tableManager;
        _combat = combat;
    }

    public abstract void DetermineReward();
    public abstract void EarnReward(Player player);

    public void Resolve()
    {
        _combat.ResolveReward();
    }
}
