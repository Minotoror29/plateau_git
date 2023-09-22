using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipNextTurnEffect : Effect
{
    public SkipNextTurnEffect(TableManager tableManager, SkipNextTurnEffectData data) : base(tableManager, data)
    {
    }

    public override void Activate()
    {
        TableManager.Player.OnTurnStart += SkipTurn;

        ResolveEffect();
    }

    private void SkipTurn(TableTurnStartState state)
    {
        state.TableManager.Player.OnTurnStart -= SkipTurn;

        state.TableManager.ChangeState(new TablePlayerMoveState(state.TableManager, 0));
    }
}
