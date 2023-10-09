using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuySpellsDisplay : MonoBehaviour
{
    private TableManager _tableManager;

    private BuySpellsEffect _effect;

    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private ShopSpellDisplay shopSpellPrefab;
    [SerializeField] private Transform spellsParent;

    private List<ShopSpellDisplay> _spells;
    private int _boughtSpells;

    public void Initialize(TableManager tableManager)
    {
        _tableManager = tableManager;
    }

    public void SetEffect(BuySpellsEffect effect)
    {
        _effect = effect;
    }

    public void SetSpells(int spellsToReveal, int spellsToBuy)
    {
        title.text = "Buy up to " + spellsToReveal + " spells. <br> If you buy " + spellsToBuy + " of them, flip the tile.";

        _spells = new();
        _boughtSpells = 0;

        for (int i = 0; i < spellsToReveal; i++)
        {
            SpellData spell = _tableManager.SpellDeck.Draw();

            if (spell != null)
            {
                ShopSpellDisplay newSpell = Instantiate(shopSpellPrefab, spellsParent);
                newSpell.Initialize(this);
                newSpell.SetData(spell);
                _spells.Add(newSpell);
            }
        }
    }

    public void BuySpell(ShopSpellDisplay spell)
    {
        if (_tableManager.Player.Gold >= spell.SpellData.goldValue)
        {
            _tableManager.Player.PutSpellInHand(spell.SpellData);
            _spells.Remove(spell);
            Destroy(spell.gameObject);
            _tableManager.Player.LoseGold(spell.SpellData.goldValue);
            _boughtSpells++;
        }
    }

    public void Confirm()
    {
        foreach (ShopSpellDisplay spell in _spells)
        {
            _tableManager.SpellDeck.PutInGraveyard(spell.SpellData);
            Destroy(spell.gameObject);
        }
        _spells.Clear();

        _effect.Confirm(_boughtSpells);
    }
}
