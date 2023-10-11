using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questNameDisplay;

    private QuestData _quest;

    public void Initialize(QuestData quest)
    {
        _quest = quest;
        questNameDisplay.text = quest.questName;
    }
}
