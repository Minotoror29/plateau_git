using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class XEffect : Effect
{
    private string _unit;

    private int _amount;

    public int Amount { get { return _amount; } }
    public string Unit { get { return _unit; } }

    protected XEffect(TableManager tableManager, TileState state, string description, string unit, int amount) : base(tableManager, state, description)
    {
        _amount = amount;
        _unit = unit;
    }
}
