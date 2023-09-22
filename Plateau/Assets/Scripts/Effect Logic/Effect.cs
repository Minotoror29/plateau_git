using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect
{
    private TableManager _tableManager;

    public event Action OnResolution;

    public TableManager TableManager { get { return _tableManager; } }

    public Effect(TableManager tableManager)
    {
        _tableManager = tableManager;
    }

    public abstract void Activate();

    public void ResolveEffect()
    {
        OnResolution?.Invoke();
    }
}
