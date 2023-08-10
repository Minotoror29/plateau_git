using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Mino
{
    public class Tile : MonoBehaviour
    {
        private TileState _currentState;
        private TileState[] states;

        private TileData _tileData;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private Tile _nextTile;

        public TileState[] States { get { return states; } }
        public SpriteRenderer SpriteRenderer { get { return spriteRenderer; } }
        public Tile NextTile { get { return _nextTile; } }

        public void Initialize(TileData tileData, Tile nextTile)
        {
            states = new TileState[2];
            states[0] = new TileState(this, tileData.frontFace, 0);
            states[1] = new TileState(this, tileData.backFace, 1);

            ChangeState(states[0]);

            _tileData = tileData;

            _nextTile = nextTile;
        }

        public void ChangeState(TileState nextState)
        {
            _currentState?.Exit();
            _currentState = nextState;
            _currentState.Enter();
        }

        public void ActivateEffect(TableManager tableManager, Player player)
        {
            _currentState.ActivateEffect(tableManager, player);
        }
    }
}
