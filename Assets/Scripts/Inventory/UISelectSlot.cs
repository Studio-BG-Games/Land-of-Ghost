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
        var amuletInstance = Instantiate(amuletView, transform);
        amuletInstance.Init(amulet);
        amuletInstance.EnableCollider(enableCollider);
    }
    public void SetItem(PotionView potionView, Potion potion, int amount, bool enableCollider)
    {
        _item = potion;
        var amuletInstance = Instantiate(potionView, transform);
        amuletInstance.Init(potion, amount);
        amuletInstance.EnableCollider(enableCollider);
    }
}
