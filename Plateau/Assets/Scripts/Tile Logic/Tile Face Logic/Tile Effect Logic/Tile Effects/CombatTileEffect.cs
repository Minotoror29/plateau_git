using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTileEffect : TileEffect
{
    private int _health;
    private int _attack;
    private List<CombatRewardData> _rewards;
    private int _resolvedRewards;
    private List<AdditionalCombatEffect> _additionalCombatEffects;

    public CombatTileEffect(TableManager tableManager, TileState state, CombatTileEffectData data, List<AdditionalCombatEffectData> additionalCombatEffectsData) : base(tableManager, state)
    {
        _health = data.health;
        _attack = data.attack;
        _rewards = new();
        foreach (CombatRewardData reward in data.rewards)
        {
            _rewards.Add(reward);
        }
        _additionalCombatEffects = new();
        foreach (AdditionalCombatEffectData additionalEffect in additionalCombatEffectsData)
        {
            _additionalCombatEffects.Add(additionalEffect.Effect(data));
        }
    }

    public override void Activate(Player player)
    {
        _resolvedRewards = 0;

        int playerDamage = TableManager.TossDice();

        if (playerDamage >= _health)
        {
            foreach (CombatRewardData reward in _rewards)
            {
                reward.EarnReward(player, this);
            }
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

    public void ResolveReward(Player player)
    {
        _resolvedRewards++;

        if (_resolvedRewards == _rewards.Count)
        {
            player.CurrentTile.FlipTile();
            Resolve();
        }
    }
}
