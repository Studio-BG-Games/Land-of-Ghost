using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TradeInventory : MonoBehaviour
{
    [SerializeField] private InventorySO _inventorySO;
    [SerializeField] private Items[] _itemsShop;
    [SerializeField] private AmuletView _amuletView;
    [SerializeField] private PotionView _potionView;
    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        ClearSlots();

    }
    private void ClearSlots()
    {

    }


}
