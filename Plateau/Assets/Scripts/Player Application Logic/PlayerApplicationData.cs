using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerApplicationData : ScriptableObject
{
    public abstract List<Player> Players(TableManager tableManager);
}
