using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AmuletView : ItemsView
{
    [SerializeField] private Amulet _currentUsed;
    public UnityEvent OnAmuletClick;
    private void OnMouseDown()
    {
        Amulet amulet = (Amulet)_item;
        _currentUsed.DamageAmount = amulet.DamageAmount;
        _currentUsed.DamageToPlayer = amulet.DamageToPlayer;
        _currentUsed.AnimationId = amulet.AnimationId;
        OnAmuletClick?.Invoke();
    }

}
