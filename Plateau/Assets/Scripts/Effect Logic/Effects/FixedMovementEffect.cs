using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMovementEffect : Effect
{
    private int _movementValue;

    public FixedMovementEffect(TableManager tableManager, TileState state, string description, int movementValue) : base(tableManager, state, description)
    {
        _movementValue = movementValue;
    }

    public override void Activate()
    {
        TableManager.CurrentPlayer.OnTurnStart += ApplyFixedMovement;

        ResolveEffect();
    }

    private void ApplyFixedMovement(TableTurnStartState state)
    {
        //A revoir
        state.TableManager.CurrentPlayer.OnTurnStart -= ApplyFixedMovement;

        state.TableManager.MoveButton.onClick.RemoveAllListeners();
        state.FixedmovementValue = _movementValue;
        state.TableManager.MoveButton.onClick.AddListener(state.MovePlayer);
    }
}
