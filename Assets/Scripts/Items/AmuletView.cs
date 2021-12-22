using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AmuletView : ItemsView
{
    [SerializeField] private Amulet _currentUsed;
    public UnityEvent OnAmuletClick;
    private void OnMouseDown()
    {
        base.MouseDown();
        Amulet amulet = (Amulet)_item;
        _currentUsed.DamageAmount = amulet.DamageAmount;
        _currentUsed.DamageToPlayer = amulet.DamageToPlayer;
        _currentUsed.AnimationId = amulet.AnimationId;
        OnAmuletClick?.Invoke();
    }

}
