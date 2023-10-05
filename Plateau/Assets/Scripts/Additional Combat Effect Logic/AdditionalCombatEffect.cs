using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AdditionalCombatEffect
{
    private CombatEffectData _combat;

    public CombatEffectData Combat { get { return _combat; } }

    public AdditionalCombatEffect(CombatEffectData combat)
    {
        _combat = combat;
    }

    public abstract void Activate(Player player);
}
