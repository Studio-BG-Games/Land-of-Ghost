using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UISelectSlot : UISlot
{
    [SerializeField] private int _idSlot;
    [SerializeField] private bool _isAmulet;
    public UnityEvent<int,bool> OnSlotClick;
    private Items _item;
    private void OnMouseDown()
    {
        OnSlotClick?.Invoke(_idSlot, _isAmulet);
    }
    public void SetItem(AmuletView amuletView, Amulet amulet, bool enableCollider)
    {
        _item = amulet;
        var instance = Instantiate(amuletView, transform);
        instance.Init(amulet);
        instance.EnableCollider(enableCollider);
    }
    public void SetItem(PotionView potionView, Potion potion, int amount, bool enableCollider)
    {
        _item = potion;
        var instance = Instantiate(potionView, transform);
        instance.Init(potion, amount);
        instance.EnableCollider(enableCollider);
    }
}
