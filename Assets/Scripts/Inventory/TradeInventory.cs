using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TradeInventory : MonoBehaviour
{
    [SerializeField] private InventorySO _inventorySO;
    [SerializeField] private Items[] _itemsShop;
    [SerializeField] private GameObject _productPrefab;
    [SerializeField] private Transform _productsConteiner;
    private Items _itemCurrent;
    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        CreateProducts();

    }
    private void CreateProducts()
    {
        var product = Instantiate(_productPrefab, _productsConteiner);
    }


}
