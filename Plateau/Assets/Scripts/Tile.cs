using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mino
{
    public class Tile : MonoBehaviour
    {
        private Tile _nextTile;

        public Tile NextTile { get { return _nextTile; } }

        public void Initialize(Tile nextTile)
        {
            _nextTile = nextTile;
        }
    }
}
