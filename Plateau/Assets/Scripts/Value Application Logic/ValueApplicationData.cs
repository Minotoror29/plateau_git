using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ValueApplicationData : ScriptableObject
{
    public abstract int Value(TableManager tableManager);
}
