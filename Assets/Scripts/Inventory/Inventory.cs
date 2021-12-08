using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventorySO _inventorySO;
    [SerializeField] private UISlot[] _uiSlots;
    [SerializeField] private UISelectSlot[] _uiAmuletSlots;
    [SerializeField] private UISelectSlot[] _uiPotionSlots;
    [SerializeField] private AmuletView _amuletView;
    [SerializeField] private PotionView _potionView;
    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        ClearSlots();
        var amulets = _inventorySO.GetAmulets();
        var potions = _inventorySO.GetPotions();
        var i = 0;
        for (i = 0; i < amulets.Count + potions.Count; i++)
        {
            if (i < amulets.Count)
                InsertAmulet(_uiSlots[i], amulets[i]);
            else
                InsertPotion(_uiSlots[i], potions[i - amulets.Count]);
        }
        for (i = 0; i < _uiAmuletSlots.Length; i++)
        {
            if(_inventorySO.AmuletsInSlot[i] != null)
                _uiAmuletSlots[i].SetItem(_amuletView,_inventorySO.AmuletsInSlot[i]);
        }
        for (i = 0; i < _uiPotionSlots.Length; i++)
        {
            if(_inventorySO.PotionsInSlot[i] != null)
                _uiPotionSlots[i].SetItem(_potionView, _inventorySO.PotionsInSlot[i]);
        }
    }
    private void ClearSlots()
    {
        foreach (var item in _uiSlots)
        {
            item.Clear();
        }
        foreach (var item in _uiAmuletSlots)
        {
            item.Clear();
        }
        foreach (var item in _uiPotionSlots)
        {
            item.Clear();
        }
    }
    private void InsertAmulet(UISlot uISlot, Amulet item)
    {
        var amulet = Instantiate(_amuletView, uISlot.transform);
        amulet.Init(item);
    }
    private void InsertPotion(UISlot uISlot, Potion item)
    {
        var potion = Instantiate(_potionView, uISlot.transform);
        potion.Init(item);
    }

}
