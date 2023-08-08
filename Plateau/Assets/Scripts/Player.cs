using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mino
{
    public class Player : MonoBehaviour
    {
        private Tile _currentTile;

        public void Initialize(Tile startTile)
        {
            _currentTile = startTile;
        }

        public void Move(int movementValue)
        {
            for (int i = 0; i < movementValue; i++)
            {
                _currentTile = _currentTile.NextTile;
            }

            transform.position = _currentTile.transform.position;
        }
    }
}
