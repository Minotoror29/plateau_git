using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerOverlay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameDisplay;
    [SerializeField] private TextMeshProUGUI healthDisplay;
    [SerializeField] private TextMeshProUGUI goldDisplay;
    [SerializeField] private Transform artifactsHand;
    [SerializeField] private Transform spellsHand;

    public Transform ArtifactsHand { get { return artifactsHand; } }
    public Transform SpellsHand { get { return spellsHand; } }

    public void SetPlayerName(string playerName)
    {
        playerNameDisplay.text = playerName;
    }

    public void SetHealthDisplay(int health)
    {
        healthDisplay.text = "HP : " + health;
    }

    public void SetgoldDisplay(int gold)
    {
        goldDisplay.text = "Gold : " + gold;
    }


}
