using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryCraft : MonoBehaviour
{
    [SerializeField] private InventorySO _inventorySO;
    [SerializeField] private UIDropSlot[] _uiSlots;
    [SerializeField] private UICraftSlot[] _uiCraftSlots;
    [SerializeField] private AmuletView _amuletView;
    [SerializeField] private PotionView _potionView;
    [SerializeField] private UICraftResultSlot _uiCraftSlot;
    [SerializeField] private VoidChannelSO _voidChannelSO;
    void Start()
    {
        ClearSlots();
        Refresh();
        _voidChannelSO.OnVoid += ClearInventory;
        _voidChannelSO.OnVoid += ClearCraftSlots;
        _voidChannelSO.OnVoid += Refresh;
    }
    public void Refresh()
    {
        var amulets = _inventorySO.GetAmulets();
        var potions = _inventorySO.GetPotions();
        var i = 0;
        for (i = 0; i < amulets.Count + potions.Count; i++)
        {
            if (i < amulets.Count)
                InsertAmulet(_uiSlots[i], amulets[i]);
            else
            {
                InsertPotion(_uiSlots[i], potions.ElementAt(i - amulets.Count).Key, potions.ElementAt(i-amulets.Count).Value);
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

    private void InsertAmulet(UIDropSlot uISlot, Amulet item)
    {
        var amulet = Instantiate(_amuletView, uISlot.transform);
        amulet.Init(item);
        amulet.EnableDragItem(true);
    }
    private void InsertPotion(UIDropSlot uISlot, Potion item, int amount)
    {
        var potion = Instantiate(_potionView, uISlot.transform);
        potion.Init(item, amount);
        potion.EnableDragItem(true);
    }

}
