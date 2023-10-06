using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ArtifactDisplay : MonoBehaviour
{
    private ArtifactData _artifactData;
    [SerializeField] private TextMeshProUGUI artifactNameText;
    [SerializeField] private TextMeshProUGUI artifactGoldValueText;

    public ArtifactData ArtifactData { get { return _artifactData; } }

    public void SetData(ArtifactData artifactData)
    {
        _artifactData = artifactData;
        artifactNameText.text = artifactData.artifactName;
        artifactGoldValueText.text = artifactData.goldValue.ToString();
    }
}
