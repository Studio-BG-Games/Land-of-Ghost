using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AmuletView : ItemsView<Amulet>
{
    [SerializeField] private Amulet _currentUsed;
    public UnityEvent OnAmuletClick;
    private void OnMouseDown()
    {
        _currentUsed.DamageAmount = _item.DamageAmount;
        _currentUsed.DamageToPlayer = _item.DamageToPlayer;
        _currentUsed.AnimationId = _item.AnimationId;
        OnAmuletClick?.Invoke();
    }
}
