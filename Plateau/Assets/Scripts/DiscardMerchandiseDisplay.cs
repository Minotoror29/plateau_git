using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiscardMerchandiseDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;

    public void Initialize(string player, string merchandiseType)
    {
        title.text = player + " must choose a " + merchandiseType + " to discard";
    }
}
