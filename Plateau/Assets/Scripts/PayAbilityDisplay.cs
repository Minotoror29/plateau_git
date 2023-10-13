using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PayAbilityDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;

    private event Action OnAccept;
    private event Action OnDecline;

    public void Initialize(Ability ability, Action acceptAction, Action declineAction)
    {
        title.text = ability.Description;

        OnAccept += acceptAction;
        OnDecline += declineAction;
    }

    public void Accept()
    {
        OnAccept?.Invoke();
    }

    public void Decline()
    {
        OnDecline?.Invoke();
    }

    public void UnsubscribeActions(Action acceptAction, Action declineAction)
    {
        OnAccept -= acceptAction;
        OnDecline -= declineAction;
    }
}
