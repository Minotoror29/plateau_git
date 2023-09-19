using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMovementEffect : TileEffect
{
    private int _movementValue;

    public FixedMovementEffect(TableManager tableManager, int movementValue) : base(tableManager)
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
        state.TableManager.MoveButton.onClick.RemoveAllListeners();
        state.FixedmovementValue = _movementValue;
        state.TableManager.MoveButton.onClick.AddListener(state.MovePlayer);

        //A revoir
        state.TableManager.Player.OnTurnStart -= ApplyFixedMovement;
    }
}
