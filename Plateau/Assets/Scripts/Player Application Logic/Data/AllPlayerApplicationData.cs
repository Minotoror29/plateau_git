using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Application/All Players")]
public class AllPlayerApplicationData : PlayerApplicationData
{
    public override List<Player> Players(TableManager tableManager)
    {
        return tableManager.Players;
    }
}
