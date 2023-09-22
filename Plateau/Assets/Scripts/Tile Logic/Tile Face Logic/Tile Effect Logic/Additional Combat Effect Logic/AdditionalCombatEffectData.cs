using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AdditionalCombatEffectData : ScriptableObject
{
    public abstract AdditionalCombatEffect Effect(CombatAbilityData combat);
}
