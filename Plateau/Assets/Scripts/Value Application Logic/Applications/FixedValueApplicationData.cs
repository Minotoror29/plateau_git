using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Value Application/Fixed")]
public class FixedValueApplicationData : ValueApplicationData
{
    public int value;

    public override int Value(TableManager tableManager)
    {
        return value;
    }
}
