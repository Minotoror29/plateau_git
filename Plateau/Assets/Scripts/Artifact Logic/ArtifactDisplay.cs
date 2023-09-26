using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArtifactDisplay : MonoBehaviour, IPointerDownHandler
{
    private TableManager _tableManager;

    private ArtifactData _artifactData;
    [SerializeField] private TextMeshProUGUI artifactNameText;

    public ArtifactData ArtifactData { get { return _artifactData; } }

    public void Initialize(TableManager tableManager, ArtifactData artifactData)
    {
        _tableManager = tableManager;

        _artifactData = artifactData;
        artifactNameText.text = artifactData.artifactName;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _tableManager.CurrentState.SelectArtifact(this);
    }
}
