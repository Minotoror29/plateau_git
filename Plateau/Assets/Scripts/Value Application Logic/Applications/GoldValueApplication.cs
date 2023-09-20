using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldValueApplication : ValueApplication
{
    public GoldValueApplication(TableManager tableManager) : base(tableManager)
    {
    }

    public override void DetermineValue()
    {
        TableManager.PayCustomGoldDisplay.gameObject.SetActive(true);
        TableManager.PayCustomGoldDisplay.Initialize(TableManager.Player, this);
    }
}
