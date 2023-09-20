using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ValueApplication
{
    private TableManager _tableManager;

    private int _value;

    public event Action OnResolution;

    public TableManager TableManager { get { return _tableManager; } }
    public int Value { get { return _value; } set { _value = value; } }

    public ValueApplication(TableManager tableManager)
    {
        _tableManager = tableManager;
    }

    public abstract void DetermineValue();

    public void Resolve()
    {
        OnResolution?.Invoke();
    }
}
