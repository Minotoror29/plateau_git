using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect
{
    private TableManager _tableManager;
    private TileState _state;

    private string _description;

    public event Action OnResolution;

    public TableManager TableManager { get { return _tableManager; } }
    public TileState State { get { return _state; } }
    public string Description { get { return _description; } }

    public Effect(TableManager tableManager, TileState state, string description)
    {
        _tableManager = tableManager;
        _state = state;
        _description = description;
    }

    public abstract void Activate();

    public void ResolveEffect()
    {
        OnResolution?.Invoke();
    }
}
