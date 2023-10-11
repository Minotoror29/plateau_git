using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiscardQuestDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;

    public void Initialize(string playerName)
    {
        title.text = playerName + " must choose a quest to discard";
    }
}
