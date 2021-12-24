using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleInventory : MonoBehaviour
{
    [SerializeField] private InventorySO _inventorySO;
    [SerializeField] private UISelectSlot[] _itemSlotPotions;
    [SerializeField] private UISelectSlot[] _itemSlotAmulets;
    [SerializeField] private AmuletView _amuletView;
    [SerializeField] private PotionView _potionView;
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private ItemsChannelSO _itemDestroy;

    void Start()
    {
        Refresh();
    }
    private void OnEnable()
    {
        _inventorySO.OnMoneyChange += RefreshMoneyInfo;
        _itemDestroy.OnItemsChannel += RemoveAmuletFromSlot;
    }
    private void OnDisable()
    {
        _inventorySO.OnMoneyChange -= RefreshMoneyInfo;
        _itemDestroy.OnItemsChannel -= RemoveAmuletFromSlot;
    }
    public void Refresh()
    {
        ClearSlots();
        var i = 0;
        for (i = 0; i < _itemSlotAmulets.Length; i++)
        {
            if (_inventorySO.AmuletsInSlot[i] != null)
                _itemSlotAmulets[i].SetItem(_amuletView, _inventorySO.AmuletsInSlot[i], true);
        }
        var potions = _inventorySO.GetPotions();
        for (i = 0; i < _itemSlotPotions.Length; i++)
        {
            if (_inventorySO.PotionsInSlot[i] != null)
                _itemSlotPotions[i].SetItem(_potionView, _inventorySO.PotionsInSlot[i], potions[_inventorySO.PotionsInSlot[i]], true);
        }
        RefreshMoneyInfo();
    }
    public void RemoveItem(int id)
    {
        _inventorySO.RemoveItem(id); 
        Refresh();
    }
    public void RemoveAmuletFromSlot(Items item)
    {
        _inventorySO.RemoveAmuletFromSlot(item); 
        Refresh();
    }
    private void RefreshMoneyInfo()
    {
        _moneyText.text = _inventorySO.Money.ToString();
    }
    private void ClearSlots()
    {
        foreach (var item in _itemSlotPotions)
        {
            item.Clear();
        }
        foreach (var item in _itemSlotAmulets)
        {
            item.Clear();
        }
    }
}
