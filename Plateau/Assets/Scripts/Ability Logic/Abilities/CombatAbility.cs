using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAbility : Ability
{
    private int _health;
    private int _attack;
    private List<CombatReward> _rewards;
    private int _resolvedRewards;
    private List<AdditionalCombatEffect> _additionalCombatEffects;

    public CombatAbility(TableManager tableManager, TileState state, CombatAbilityData data, List<AdditionalCombatEffectData> additionalCombatEffectsData) : base(tableManager, state)
    {
        _health = data.health;
        _attack = data.attack;
        _rewards = new();
        foreach (CombatRewardData reward in data.rewards)
        {
            _rewards.Add(reward.Reward(tableManager, this));
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
            _rewards[0].DetermineReward();
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

    public void ResolveReward()
    {
        _resolvedRewards++;

        if (_resolvedRewards == _rewards.Count)
        {
            foreach (CombatReward reward in _rewards)
            {
                reward.EarnReward(TableManager.Player);
            }
            State.FlipTile();
            Resolve();
        } else
        {
            _rewards[_resolvedRewards].DetermineReward();
        }
    }
}
