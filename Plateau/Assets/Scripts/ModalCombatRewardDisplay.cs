using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModalCombatRewardDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldAmountText;
    [SerializeField] private TextMeshProUGUI artifactAmountText;

    private Player _player;
    private TileEffect _effect;

    private int _goldAmount;
    private int _artifactAmount;

    public void SetRewards(Player player, TileEffect effect, int goldAmount, int artifactAmount)
    {
        _player = player;
        _effect = effect;

        _goldAmount = goldAmount;
        _artifactAmount = artifactAmount;

        goldAmountText.text = goldAmount.ToString();
        artifactAmountText.text = artifactAmount.ToString();
    }

    public void EarnGold()
    {
        _player.EarnGold(_goldAmount);
        _effect.Resolve();
        gameObject.SetActive(false);
    }

    public void EarnArtifact()
    {
        _player.DrawArtifact(_artifactAmount);
        _effect.Resolve();
        gameObject.SetActive(false);
    }
}
