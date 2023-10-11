using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuestDisplay : MonoBehaviour, IPointerDownHandler
{
    private TableManager _tableManager;
    private QuestData _quest;

    [SerializeField] private TextMeshProUGUI questNameDisplay;

    public QuestData QuestData { get { return _quest; } }

    public void Initialize(TableManager tableManager, QuestData quest)
    {
        _tableManager = tableManager;
        _quest = quest;
        questNameDisplay.text = quest.questName;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _tableManager.CurrentState.SelectQuest(this);
    }
}
