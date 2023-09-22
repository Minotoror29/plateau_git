using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Face")]
public class TileFaceData : ScriptableObject
{
    public Color faceColor;
    public List<AbilityData> abilities;
}
