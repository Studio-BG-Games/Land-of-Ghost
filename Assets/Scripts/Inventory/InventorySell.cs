using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class InventorySell : MonoBehaviour
{
    [SerializeField] private InventorySO _inventorySO;
    [SerializeField] private UIDropSlot[] _uiSlots;
    [SerializeField] private UICraftSlot _uiSellSlot;
    [SerializeField] private UIMoneySlot _uiMoneySlot;
    [SerializeField] private TextMeshProUGUI _playerMoneyText;
    private int _itemSellId;
    private int _itemSellPrice;
    private void Start()
    {
        _inventorySO.OnMoneyChange += DisplayMoney;
        ClearSlots();
        Refresh();
    }
    public void Refresh()
    {
        var potions = _inventorySO.GetPotions();
        var commons = _inventorySO.GetCommons();
        var i = 0;
        for (i = 0; i <  potions.Count + commons.Count; i++)
        {
             if (i <  potions.Count)
            {
                var element = potions.ElementAt(i).Key;
                InsertItem(_uiSlots[i], element, potions.ElementAt(i).Value);
            }
            else
            {
                var index = i - potions.Count;
                var element = commons.ElementAt(index).Key;
                InsertItem(_uiSlots[i], element, commons.ElementAt(index).Value);
            }
        }
    }
    public void ClearSlots()
    {
        ClearInventory();
        _uiSellSlot.Clear();
        _uiMoneySlot.Clear();
    }
    private void DisplayMoney()
    {
        _playerMoneyText.text = $"- {_inventorySO.Money}";
    }
    private void ClearInventory()
    {
        foreach (var item in _uiSlots)
        {
            item.Clear();
        }
    }
    private void InsertItem(UIDropSlot uISlot, Items item, int amount = 1)
    {
        var newItem = Instantiate(item.View, uISlot.transform);
        newItem.Init(item, amount);
        newItem.EnableDragItem(true);
    }
    public void ShowPrice(int id)
    {
        if (id == 0)
            _itemSellPrice = 0;
        else
            _itemSellPrice = _inventorySO.AllItems.Where(item => item.Id == id).Select(item => item.MoneyPrice).First();
        _uiMoneySlot.ItemSellChange(_itemSellPrice);
    }
    public void Sell()
    {
        if (_itemSellId == 0)
            return;
        _inventorySO.RemoveItem(_itemSellId);
        _inventorySO.AddMoney(_itemSellPrice);
        ClearSlots();
        Refresh();
    }
    public void SetItemSell(int id)
    {
        _itemSellId = id;
        ShowPrice(id);
    }
}
