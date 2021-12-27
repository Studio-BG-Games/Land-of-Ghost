using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryCraft : MonoBehaviour
{
    [SerializeField] private InventorySO _inventorySO;
    [SerializeField] private UIDropSlot[] _uiSlots;
    [SerializeField] private UICraftSlot[] _uiCraftSlots;
    [SerializeField] private UICraftResultSlot _uiCraftSlot;
    [SerializeField] private VoidChannelSO _craftClearChannelSO;
    [SerializeField] private GameObjectChannelSO _beginDragChannelSO;
    [SerializeField] private GameObjectChannelSO _endDragNowereChannelSO;
    private void Start()
    {
        ClearSlots();
        Refresh();
        _craftClearChannelSO.OnVoid += CraftItem;
        _beginDragChannelSO.OnGameObjectChannel += DivideItem;
        _endDragNowereChannelSO.OnGameObjectChannel += RetutnItemBack;
    }
    private void OnDisable()
    {
        _craftClearChannelSO.OnVoid -= CraftItem;
        _beginDragChannelSO.OnGameObjectChannel -= DivideItem;
        _endDragNowereChannelSO.OnGameObjectChannel -= RetutnItemBack;
    }
    public void Refresh()
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
                InsertItem(_uiSlots[i], element,potions.ElementAt(index).Value);
            }
            else
            {
                var index = i - amulets.Count - potions.Count;
                var element = commons.ElementAt(index).Key;
                InsertItem(_uiSlots[i], element,commons.ElementAt(index).Value);
            }
        }
    }
    public void ClearSlots() 
    {
        ClearInventory();
        ClearCraftSlots();
        _uiCraftSlot.Clear();
        _uiCraftSlot.Zero(); 
    }
    private void ClearCraftSlots()
    {
        foreach (var item in _uiCraftSlots)
        {
            item.Clear();
        }
    }
    private void ClearInventory()
    {
        foreach (var item in _uiSlots)
        {
            item.Clear();
        }
    }
    private void CraftItem()
    {
        foreach (var slot in _uiCraftSlots)
        {
            slot.Craft();
        }
        ClearInventory();
        ClearCraftSlots();
        Refresh();
        _inventorySO.AddItem(_uiCraftSlot.NewItem);
    }
    private void DivideItem(GameObject gameObject)
    {
        var view = gameObject.GetComponent<ItemsView>();
        var item = _inventorySO.GetItemById(view.Id);
        var amount = view.Amount;
        if (amount < 2) return;
        var uiSlot = gameObject.transform.parent.GetComponent<UIDropSlot>();
        view.ChangeAmount(1);
        InsertItem(uiSlot, item, amount - 1);
    }
    private void RetutnItemBack(GameObject gameObject)
    {
        var view = gameObject.GetComponent<ItemsView>();
        var amount = view.Amount;
        var uiSlot = gameObject.transform.parent;
        Destroy(gameObject);
        var overView = uiSlot.GetChild(0).GetComponent<ItemsView>();
        overView.ChangeAmount(overView.Amount + amount);

    }
    private void InsertItem(UIDropSlot uISlot, Items item, int amount = 1)
    {
        var newItem = Instantiate(item.View, uISlot.transform);
        newItem.Init(item, amount);
        newItem.EnableDragItem(true);
    }

}
