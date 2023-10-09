using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Coin Flip")]
public class CoinFlipAbilityData : AbilityData
{
    public EffectData evenEffect;
    public EffectData oddEffect;

    public override Ability Ability(TableManager tableManager, TileState state)
    {
        return new CoinFlipAbility(tableManager, state, this);
    }
}
