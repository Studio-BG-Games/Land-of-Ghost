using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UISelectSlot : MonoBehaviour
{
    [SerializeField] private int _idSlot;
    [SerializeField] private bool _isAmulet;
    public UnityEvent<int,bool> OnAmuletSlotClick;
    private Items _item;
    private void OnMouseDown()
    {
        OnAmuletSlotClick?.Invoke(_idSlot, _isAmulet);
    }
    public void SetItem(AmuletView amuletView, Amulet amulet)
    {
        _item = amulet;
        var amuletInstance = Instantiate(amuletView, transform);
        amuletInstance.Init(amulet);
        amuletInstance.EnableCollider(false);
    }
    public void SetItem(PotionView potionView, Potion potion)
    {
        _item = potion;
        var amuletInstance = Instantiate(potionView, transform);
        amuletInstance.Init(potion);
        amuletInstance.EnableCollider(false);
    }
    public void Clear()
    {
        if (transform.childCount > 0)
            Destroy(transform.GetChild(0).gameObject);
    }
}
