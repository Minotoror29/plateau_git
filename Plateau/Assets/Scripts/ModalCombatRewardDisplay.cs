using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModalCombatRewardDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldAmountText;
    [SerializeField] private TextMeshProUGUI artifactAmountText;

    private ModalCombatReward _reward;

    public void Initialize(ModalCombatReward reward, int goldAmount, int artifactAmount)
    {
        _reward = reward;

        goldAmountText.text = goldAmount.ToString();
        artifactAmountText.text = artifactAmount.ToString();
    }

    public void EarnGold()
    {
        _reward.HasChosenGold = true;
        _reward.Resolve();
        gameObject.SetActive(false);
    }

    public void EarnArtifact()
    {
        _reward.HasChosenGold = false;
        _reward.Resolve();
        gameObject.SetActive(false);
    }
}
