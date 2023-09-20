using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedValueApplication : ValueApplication
{
    private FixedValueApplicationData _data;

    public FixedValueApplication(TableManager tableManager, FixedValueApplicationData data) : base (tableManager)
    {
        _data = data;
    }

    public override void DetermineValue()
    {
        Value = _data.value;
        Resolve();
    }
}
