using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipNextTurnEffect : Effect
{
    public SkipNextTurnEffect(TableManager tableManager, TileState state, string description) : base(tableManager, state, description)
    {
    }

    public override void Activate()
    {
        TableManager.CurrentPlayer.OnTurnStart += SkipTurn;

        ResolveEffect();
    }

    private void SkipTurn(TableTurnStartState state)
    {
        state.TableManager.CurrentPlayer.OnTurnStart -= SkipTurn;

        state.TableManager.ChangeState(new TablePlayerMoveState(state.TableManager, new TableDefaultSubstate(state.TableManager), 0));
    }
}
