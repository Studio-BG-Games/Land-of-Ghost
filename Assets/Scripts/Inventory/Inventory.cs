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
    private void Start()
    {
        Refresh();
    }
    public void Refresh()
    {
        ClearSlots();
        var amulets = _inventorySO.GetAmulets();
        var potionsNotInSlot = _inventorySO.GetPotionsNotInSlot();
        var i = 0;
        for (i = 0; i < amulets.Count + potionsNotInSlot.Count; i++)
        {
            if (i < amulets.Count)
                InsertAmulet(_uiSlots[i], amulets[i]);
            else
            {
                var potion = potionsNotInSlot.ElementAt(i - amulets.Count).Key;
                if (!_inventorySO.PotionsInSlot.Contains(potion))
                    InsertPotion(_uiSlots[i], potion, potionsNotInSlot[potion]);
            }
        }
        for (i = 0; i < _uiAmuletSlots.Length; i++)
        {
            if(_inventorySO.AmuletsInSlot[i] != null)
                _uiAmuletSlots[i].SetItem(_amuletView,_inventorySO.AmuletsInSlot[i], false);
        }
        var potions = _inventorySO.GetPotions();
        for (i = 0; i < _uiPotionSlots.Length; i++)
        {
            if(_inventorySO.PotionsInSlot[i] != null)
                _uiPotionSlots[i].SetItem(_potionView, _inventorySO.PotionsInSlot[i], potions[_inventorySO.PotionsInSlot[i]], false);
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
    private void InsertPotion(UISlot uISlot, Potion item, int amount)
    {
        var potion = Instantiate(_potionView, uISlot.transform);
        potion.Init(item, amount);
    }

}
