using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AdditionalCombatEffect
{
    private CombatTileEffectData _combat;

    public CombatTileEffectData Combat { get { return _combat; } }

    public AdditionalCombatEffect(CombatTileEffectData combat)
    {
        _combat = combat;
    }

    public abstract void Activate(Player player);
}
