using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Value Application/Pay Gold")]
public class GoldValueApplicationData : ValueApplicationData
{
    public override ValueApplication Value(TableManager tableManager)
    {
        return new GoldValueApplication(tableManager);
    }
}
