using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArtifactDisplay : MonoBehaviour
{
    private ArtifactData _artifact;
    [SerializeField] private TextMeshProUGUI artifactNameText;

    public void Initialize(ArtifactData artifact)
    {
        _artifact = artifact;
        artifactNameText.text = artifact.artifactName;
    }
}
