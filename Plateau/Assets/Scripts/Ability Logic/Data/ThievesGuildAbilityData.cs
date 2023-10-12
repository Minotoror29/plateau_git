using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Thieves Guild Ability")]
public class ThievesGuildAbilityData : AbilityData
{
    public AbilityData loseGoldAbility;
    public AbilityData loseArtifactsAbility;

    public override Ability Ability(TableManager tableManager, TileState state)
    {
        return new ThievesGuildAbility(tableManager, state, description, this);
    }
}
