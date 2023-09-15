using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTileEffect : TileEffect
{
    private int _health;
    private int _attack;
    private CombatRewardData _reward;

    public CombatTileEffect(TableManager tableManager, CombatTileEffectData data) : base(tableManager)
    {
        _health = data.health;
        _attack = data.attack;
        _reward = data.reward;
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
            Resolve();
        }
    }
}
