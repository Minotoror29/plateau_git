using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Application/You")]
public class YouPlayerApplicationData : PlayerApplicationData
{
    public override List<Player> Players(TableManager tableManager)
    {
        return new List<Player> { tableManager.CurrentPlayer };
    }
}
