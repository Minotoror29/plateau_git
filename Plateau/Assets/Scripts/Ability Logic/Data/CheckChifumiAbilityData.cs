using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Check Chifumi")]
public class CheckChifumiAbilityData : AbilityData
{
    public EffectData effect;

    public override Ability Ability(TableManager tableManager, TileState state)
    {
        return new CheckChifumiAbility(tableManager, state, description, this);
    }
}
