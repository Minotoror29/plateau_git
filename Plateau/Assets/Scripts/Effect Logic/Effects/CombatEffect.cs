using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEffect : Effect
{
    private int _health;
    private int _attack;
    private List<CombatReward> _rewards;
    private int _resolvedRewards;
    private List<AdditionalCombatEffect> _additionalCombatEffects;

    public CombatEffect(TableManager tableManager, TileState state, string description, CombatEffectData data) : base(tableManager, state, description)
    {
        _health = data.health;
        _attack = data.attack;
        _rewards = new();
        foreach (CombatRewardData reward in data.rewards)
        {
            _rewards.Add(reward.Reward(tableManager, this));
        }
        _additionalCombatEffects = new();
        foreach (AdditionalCombatEffectData additionalEffect in data.additionalCombatEffects)
        {
            _additionalCombatEffects.Add(additionalEffect.Effect(data));
        }
    }

    public override void Activate()
    {
        _resolvedRewards = 0;

        int playerDamage = TableManager.TossDice();

        if (playerDamage >= _health)
        {
            _rewards[0].DetermineReward();
        }
        else
        {
            TableManager.Player.TakeDamage(_attack);
            foreach (AdditionalCombatEffect additionalEffect in _additionalCombatEffects)
            {
                additionalEffect.Activate(TableManager.Player);
            }
            ResolveEffect();
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

            if (TableManager.Player.Artifacts.Count > TableManager.Player.MaximumArtifacts)
            {
                TableManager.CurrentState.ChangeSubstate(new TableDiscardArtifactSubstate(TableManager, TableManager.Player.Artifacts.Count - TableManager.Player.MaximumArtifacts, this));
            }
            else
            {
                ResolveEffect();
            }
        } else
        {
            _rewards[_resolvedRewards].DetermineReward();
        }
    }
}
