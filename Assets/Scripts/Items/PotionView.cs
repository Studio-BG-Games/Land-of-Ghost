using UnityEngine;
using UnityEngine.Events;

public class PotionView : ItemsView
{
    [SerializeField] private Potion _currentUsed;
    public UnityEvent OnPotionClick;
    private void OnMouseDown()
    {
        base.MouseDown();
        Potion potion = (Potion)_item;
        _currentUsed.DamageBoostPercent = potion.DamageBoostPercent;
        _currentUsed.DamageBoostTurnsCount = potion.DamageBoostTurnsCount;
        _currentUsed.DefenceBoostPercent = potion.DefenceBoostPercent;
        _currentUsed.DefenceBoostTurnsCount = potion.DefenceBoostTurnsCount;
        _currentUsed.HealAmount = potion.HealAmount;
        _currentUsed.Id = potion.Id;
        OnPotionClick?.Invoke();
    }
}
