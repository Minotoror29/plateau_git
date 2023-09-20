using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PayToFlipDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;

    private Player _player;
    private TileEffect _effect;
    private int _goldAmount;

    public void Initialize(Player player, TileEffect effect, int goldAmount)
    {
        _player = player;
        _effect = effect;
        _goldAmount = goldAmount;

        title.text = "PAY " + goldAmount.ToString() + " TO FLIP ?";
    }

    public void Accept()
    {
        if (_player.Gold >= _goldAmount)
        {
            _player.LoseGold(_goldAmount);
            _player.CurrentTile.FlipTile();
            gameObject.SetActive(false);
            _effect.Resolve();
        }
    }

    public void Decline()
    {
        gameObject.SetActive(false);
        _effect.Resolve();
    }
}
