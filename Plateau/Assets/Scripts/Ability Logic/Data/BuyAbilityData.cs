using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyAbilityData : AbilityData
{
    public int merchandiseToReveal;
    public int merchandiseToBuy;

    public override Ability Ability(TableManager tableManager, TileState state)
    {
        return new BuyAbility(tableManager, state);
    }
}
