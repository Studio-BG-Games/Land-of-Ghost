using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventorySO _inventorySO;
    [SerializeField] private UISlot[] _uiSlots;
    [SerializeField] private AmuletView _amuletView;
    [SerializeField] private PotionView _potionView;
    void Start()
    {
        var amulets = _inventorySO.GetAmulets();
        var potions = _inventorySO.GetPotions();
        var i = 0;
        foreach (var item in amulets)
        {
            InsertAmulet(_uiSlots[i], item);
            i++;
        }
        var voidSlots = _uiSlots.Where(s => s.transform.childCount == 0).ToList();
        i = 0;
        foreach (var item in potions)
        {
            InsertPotion(voidSlots[i], item);
            i++;
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
