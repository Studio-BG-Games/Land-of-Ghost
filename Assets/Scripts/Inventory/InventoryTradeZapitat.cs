using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryTradeZapitat : MonoBehaviour
{
    [SerializeField] private InventorySO _inventorySO;
    [SerializeField] private UISlot[] _uiSlots;
    private void Start()
    {
        ClearSlots();
        Refresh();
    }
    private void Refresh()
    {
        var amulets = _inventorySO.GetAmulets();
        var potions = _inventorySO.GetPotions();
        var commons = _inventorySO.GetCommons();
        var i = 0;
        for (i = 0; i < amulets.Count + potions.Count + commons.Count; i++)
        {
            if (i < amulets.Count)
                InsertItem(_uiSlots[i], amulets[i]);
            else if (i < amulets.Count + potions.Count)
            {
                var index = i - amulets.Count;
                var element = potions.ElementAt(index).Key;
                InsertItem(_uiSlots[i], element, potions.ElementAt(index).Value);
            }
            else
            {
                var index = i - amulets.Count - potions.Count;
                var element = commons.ElementAt(index).Key;
                InsertItem(_uiSlots[i], element, commons.ElementAt(index).Value);
            }
        }
    }
    private void ClearSlots()
    {
        foreach (var item in _uiSlots)
        {
            item.Clear();
        }
    }
    private void InsertItem(UISlot uISlot, Items item, int amount = 1)
    {
        var newItem = Instantiate(item.View, uISlot.transform);
        newItem.Init(item, amount);
        newItem.EnableDragItem(false);
    }

}
