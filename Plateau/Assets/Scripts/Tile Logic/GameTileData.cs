using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile")]
public class GameTileData : ScriptableObject
{
    public string tileName;
    public Color tileColor;

    public TileEffectData effect;
}
