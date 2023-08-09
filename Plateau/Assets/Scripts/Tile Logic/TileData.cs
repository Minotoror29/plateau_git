using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile")]
public class TileData : ScriptableObject
{
    public string tileName;

    public TileFaceData frontFace;
    public TileFaceData backFace;
}
