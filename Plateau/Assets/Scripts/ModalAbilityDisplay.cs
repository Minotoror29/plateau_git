using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModalAbilityDisplay : MonoBehaviour
{
    private Ability _ability1;
    [SerializeField] private TextMeshProUGUI ability1Description;
    private Ability _ability2;
    [SerializeField] private TextMeshProUGUI ability2Description;

    public void Initialize(Ability ability1, Ability ability2)
    {
        _ability1 = ability1;
        ability1Description.text = ability1.Description;
        _ability2 = ability2;
        ability2Description.text = ability2.Description;
    }

    public void ChooseAbility1()
    {
        _ability1.Activate();
        gameObject.SetActive(false);
    }

    public void ChooseAbility2()
    {
        _ability2.Activate();
        gameObject.SetActive(false);
    }
}
