using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile")]
public class TileData : ScriptableObject
{
    public TileFaceData frontFace;
    public TileFaceData backFace;
}
