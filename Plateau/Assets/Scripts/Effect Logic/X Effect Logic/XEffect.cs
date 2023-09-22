using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class XEffect : Effect
{
    private string _description2;

    private int _amount;

    public int Amount { get { return _amount; } }
    public string Description2 { get { return _description2; } }

    protected XEffect(TableManager tableManager, string description, string description2, int amount) : base(tableManager, description)
    {
        _amount = amount;
        _description2 = description2;
    }
}
