using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AdditionalCombatEffect
{
    private CombatAbilityData _combat;

    public CombatAbilityData Combat { get { return _combat; } }

    public AdditionalCombatEffect(CombatAbilityData combat)
    {
        _combat = combat;
    }

    public abstract void Activate(Player player);
}
