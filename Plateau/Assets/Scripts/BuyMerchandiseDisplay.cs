using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMerchandiseDisplay : MonoBehaviour
{
    private TableManager _tableManager;

    private BuyEffect _effect;

    [SerializeField] private ShopArtifactDisplay shopArtifactPrefab;
    [SerializeField] private Transform merchandisesParent;

    private List<ShopArtifactDisplay> _artifacts;
    private int _boughtArtifacts;

    public void Initialize(TableManager tableManager)
    {
        _tableManager = tableManager;
    }

    public void SetEffect(BuyEffect effect)
    {
        _effect = effect;
    }

    public void SetArtifacts(int amount)
    {
        _artifacts = new();
        _boughtArtifacts = 0;

        for (int i = 0; i < amount; i++)
        {
            ArtifactData artifact = _tableManager.ArtifactDeck.Draw();

            if (artifact != null)
            {
                ShopArtifactDisplay newArtifact = Instantiate(shopArtifactPrefab, merchandisesParent);
                newArtifact.Initialize(this);
                newArtifact.SetData(artifact);
                _artifacts.Add(newArtifact);
            }
        }
    }

    public void BuyArtifact(ShopArtifactDisplay artifact)
    {
        if (_tableManager.Player.Gold >= artifact.ArtifactData.goldValue)
        {
            _tableManager.Player.PutArtifactInHand(artifact.ArtifactData);
            _artifacts.Remove(artifact);
            Destroy(artifact.gameObject);
            _tableManager.Player.LoseGold(artifact.ArtifactData.goldValue);
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
