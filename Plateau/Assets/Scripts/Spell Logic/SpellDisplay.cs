using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class SpellDisplay : MonoBehaviour
{
    private SpellData _spellData;
    [SerializeField] private TextMeshProUGUI spellNameText;
    [SerializeField] private TextMeshProUGUI spellGoldValueText;

    public SpellData SpellData { get { return _spellData; } }

    public void SetData(SpellData spellData)
    {
        _spellData = spellData;
        spellNameText.text = spellData.spellName;
        spellGoldValueText.text = spellData.goldValue.ToString();
    }
}
