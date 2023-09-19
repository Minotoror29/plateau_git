using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMovementEffect : TileEffect
{
    private int _movementValue;

    public FixedMovementEffect(TableManager tableManager, TileState state, int movementValue) : base(tableManager, state)
    {
        _movementValue = movementValue;
    }

    public override void Activate(Player player)
    {
        player.OnTurnStart += ApplyFixedMovement;

        Resolve();
    }

    private void ApplyFixedMovement(TableTurnStartState state)
    {
        //A revoir
        state.TableManager.Player.OnTurnStart -= ApplyFixedMovement;

        state.TableManager.MoveButton.onClick.RemoveAllListeners();
        state.FixedmovementValue = _movementValue;
        state.TableManager.MoveButton.onClick.AddListener(state.MovePlayer);
    }
}
