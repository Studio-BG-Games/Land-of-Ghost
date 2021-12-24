using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AmuletView : ItemsView
{
    [SerializeField] private Amulet _currentUsed;
    public UnityEvent OnAmuletClick;
    public UnityEvent<Items> OnItemDestroy;
    private Amulet _amulet;
    private int _countUses;
    private void Start()
    {
        _amulet = (Amulet)_item;
        _countUses = _amulet.CountUses;
    }
    private void OnMouseDown()
    {
        base.MouseDown();
        _currentUsed.DamageAmount = _amulet.DamageAmount;
        _currentUsed.DamageToPlayer = _amulet.DamageToPlayer;
        _currentUsed.AnimationId = _amulet.AnimationId;
        _currentUsed.CountUses = _countUses;
        OnAmuletClick?.Invoke();
        _countUses = _currentUsed.CountUses;
        if (_countUses == 0) OnItemDestroy?.Invoke(_item);
    }

}
