using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTileEffect : TileEffect
{
    private int _health;
    private int _attack;
    private CombatRewardData _reward;
    private List<AdditionalCombatEffect> _additionalCombatEffects;

    public CombatTileEffect(TableManager tableManager, CombatTileEffectData data, List<AdditionalCombatEffectData> additionalCombatEffectsData) : base(tableManager)
    {
        _health = data.health;
        _attack = data.attack;
        _reward = data.reward;
        _additionalCombatEffects = new();
        foreach (AdditionalCombatEffectData additionalEffect in additionalCombatEffectsData)
        {
            _additionalCombatEffects.Add(additionalEffect.Effect(data));
        }
    }

    public override void Activate(Player player)
    {
        int playerDamage = TableManager.TossDice();

        if (playerDamage >= _health)
        {
            _reward.EarnReward(player, this);
            player.CurrentTile.SwitchFace();
        }
        else
        {
            player.TakeDamage(_attack);
            foreach (AdditionalCombatEffect additionalEffect in _additionalCombatEffects)
            {
                additionalEffect.Activate(player);
            }
            Resolve();
        }
    }
}
