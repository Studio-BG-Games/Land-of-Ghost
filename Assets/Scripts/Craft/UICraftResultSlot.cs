using System;
using System.Collections.Generic;
using UnityEngine;

public class UICraftResultSlot : UISlot
{
    [SerializeField] private CraftReciepts _craftReciepts;
    [SerializeField] private InventorySO _inventorySO;
    private int _item1;
    private int _item2;
    public Items NewItem { get; private set; }
    public void SetItem1(int item)
    {
        _item1 = item;
        TryToCraft();
    }
    public void SetItem2(int item)
    {
        _item2 = item;
        TryToCraft();
    }
    public void TryToCraft()
    {
        Clear();
        if (_item2 == 0 || _item1 == 0)
            return;
        var pair = new HashSet<int> { _item1, _item2 };
        foreach (var reciept in _craftReciepts.CraftMap)
        {
            if (pair.IsSupersetOf(reciept.Key))
            {
                var allItems = _inventorySO.AllItems;
                foreach (var item in allItems)
                    if(reciept.Value == item.Id)
                    {
                        Instantiating(item);
                        return;
                    }
            }
        }
    }
    public void Zero()
    {
        _item1 = 0;
        _item2 = 0;
        NewItem = null;
    }
    private void Instantiating(Items newItem)
    {
        NewItem = newItem;
        Amulet amulet = newItem as Amulet;
        if (amulet != null)
        {
            var newAmulet = Instantiate(amulet.View, transform);
            newAmulet.Init(amulet);
            newAmulet.EnableDragItem(true);
            var drag = newAmulet.GetComponent<UIDragItem>();
            drag.SetCrafted(true);
        }
        else
        {
            var newPotion = Instantiate(newItem.View, transform);
            newPotion.Init(newItem,1);
            newPotion.EnableDragItem(true);
            var drag = newPotion.GetComponent<UIDragItem>();
            drag.SetCrafted(true);
        }
    }
}