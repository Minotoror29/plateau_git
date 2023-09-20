using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Value Application/Dice")]
public class DiceValueApplicationData : ValueApplicationData
{
    public override ValueApplication Value(TableManager tableManager)
    {
        return new DiceValueApplication(tableManager);
    }
}
