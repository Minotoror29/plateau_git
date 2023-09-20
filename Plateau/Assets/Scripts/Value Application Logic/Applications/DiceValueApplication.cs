using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceValueApplication : ValueApplication
{
    public DiceValueApplication(TableManager tableManager) : base(tableManager)
    {
    }

    public override void DetermineValue()
    {
        Value = TableManager.TossDice();
        Resolve();
    }
}
