using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyArtifactsDisplay : MonoBehaviour
{
    private TableManager _tableManager;

    private BuyArtifactsEffect _effect;

    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private ShopArtifactDisplay shopArtifactPrefab;
    [SerializeField] private Transform artifactsParent;

    private List<ShopArtifactDisplay> _artifacts;
    private int _boughtArtifacts;

    public void Initialize(TableManager tableManager)
    {
        _tableManager = tableManager;
    }

    public void SetEffect(BuyArtifactsEffect effect)
    {
        _effect = effect;
    }

    public void SetArtifacts(int artifactsToReveal, int artifactsToBuy)
    {
        title.text = "Buy up to " + artifactsToReveal + " artifacts. <br> If you buy " + artifactsToBuy + " of them, flip the tile.";

        _artifacts = new();
        _boughtArtifacts = 0;

        for (int i = 0; i < artifactsToReveal; i++)
        {
            ArtifactData artifact = _tableManager.ArtifactDeck.Draw();

            if (artifact != null)
            {
                ShopArtifactDisplay newArtifact = Instantiate(shopArtifactPrefab, artifactsParent);
                newArtifact.Initialize(this);
                newArtifact.SetData(artifact);
                _artifacts.Add(newArtifact);
            }
        }
    }

    public void BuyArtifact(ShopArtifactDisplay artifact)
    {
        if (_tableManager.CurrentPlayer.Gold >= artifact.ArtifactData.goldValue)
        {
            _tableManager.CurrentPlayer.PutArtifactInHand(artifact.ArtifactData);
            _artifacts.Remove(artifact);
            Destroy(artifact.gameObject);
            _tableManager.CurrentPlayer.LoseGold(artifact.ArtifactData.goldValue);
            _boughtArtifacts++;
        }
    }

    public void Confirm()
    {
        foreach (ShopArtifactDisplay artifact in _artifacts)
        {
            _tableManager.ArtifactDeck.PutInGraveyard(artifact.ArtifactData);
            Destroy(artifact.gameObject);
        }
        _artifacts.Clear();

        _effect.Confirm(_boughtArtifacts);
    }
}
