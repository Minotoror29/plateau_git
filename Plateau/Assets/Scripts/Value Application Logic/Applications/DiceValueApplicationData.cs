using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Value Application/Dice")]
public class DiceValueApplicationData : ValueApplicationData
{
    public override int Value(TableManager tableManager)
    {
        return tableManager.TossDice();
    }
}
