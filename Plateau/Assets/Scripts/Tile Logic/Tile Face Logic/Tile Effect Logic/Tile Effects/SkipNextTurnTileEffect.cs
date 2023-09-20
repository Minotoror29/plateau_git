using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipNextTurnTileEffect : TileEffect
{
    public SkipNextTurnTileEffect(TableManager tableManager, TileState state) : base(tableManager, state)
    {
    }

    public override void Activate(Player player)
    {
        player.OnTurnStart += SkipTurn;

        Resolve();
    }

    private void SkipTurn(TableTurnStartState state)
    {
        state.TableManager.Player.OnTurnStart -= SkipTurn;

        state.TableManager.ChangeState(new TablePlayerMoveState(state.TableManager, 0));
    }
}
