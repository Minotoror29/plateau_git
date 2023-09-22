using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect
{
    private TableManager _tableManager;

    private string _description;

    public event Action OnResolution;

    public TableManager TableManager { get { return _tableManager; } }
    public string Description { get { return _description; } }

    public Effect(TableManager tableManager, string description)
    {
        _tableManager = tableManager;
        _description = description;
    }

    public abstract void Activate();

    public void ResolveEffect()
    {
        OnResolution?.Invoke();
    }
}
