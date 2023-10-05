using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMerchandiseDisplay : MonoBehaviour
{
    private TableManager _tableManager;

    private BuyEffect _ability;

    [SerializeField] private ShopArtifactDisplay shopArtifactPrefab;
    [SerializeField] private Transform merchandisesParent;

    private List<ShopArtifactDisplay> _artifacts;
    private int _boughtArtifacts;

    public void Initialize(TableManager tableManager)
    {
        _tableManager = tableManager;
    }

    public void SetAbility(BuyEffect ability)
    {
        _ability = ability;
    }

    public void SetArtifacts(int amount)
    {
        _artifacts = new();
        _boughtArtifacts = 0;

        for (int i = 0; i < amount; i++)
        {
            ArtifactData artifact = _tableManager.DrawArtifact();

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
        _tableManager.Player.PutArtifactInHand(artifact.ArtifactData);
        _artifacts.Remove(artifact);
        Destroy(artifact.gameObject);

        _boughtArtifacts++;
    }

    public void Confirm()
    {
        foreach (ShopArtifactDisplay artifact in _artifacts)
        {
            _tableManager.PutArtifactInGraveyard(artifact.ArtifactData);
            Destroy(artifact.gameObject);
        }
        _artifacts.Clear();

        _ability.Confirm(_boughtArtifacts);
    }
}
