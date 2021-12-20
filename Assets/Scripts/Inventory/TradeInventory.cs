using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class TradeInventory : MonoBehaviour
{
    [SerializeField] private InventorySO _inventorySO;
    [SerializeField] private Items[] _itemsShop;
    [SerializeField] private ProductView _productPrefab;
    [SerializeField] private TweenMover _productsConteiner;
    [SerializeField] private TextMeshProUGUI _playerMoneyText;
    [SerializeField] private float _intervalX;
    private Items _itemCurrent;
    private int _itemCurrentId;
    void Start()
    {
        _inventorySO.OnMoneyChange += DisplayMoney;
        Refresh();
    }
    public void Refresh()
    {
        CreateProducts();
        ChangeCurrent(0);
        DisplayMoney();
    }
    private void ChangeCurrent(int id)
    {
        _itemCurrentId = id;
        _itemCurrent = _itemsShop[_itemCurrentId];
    }
    private void DisplayMoney()
    {
        _playerMoneyText.text = $"- {_inventorySO.Money}";
    }
    private void CreateProducts()
    {
        for (int i = 0; i < _itemsShop.Length; i++)
        {
            var product = Instantiate(_productPrefab, _productsConteiner.transform);
            product.Init(_itemsShop[i]);

        }
    }
    public void BuyProduct()
    {
        if (_inventorySO.Money < _itemCurrent.MoneyPrice || !_inventorySO.HaveItem(_itemCurrent.ItemPrice))
            return;
        _inventorySO.RemoveMoney(_itemCurrent.MoneyPrice);
        _inventorySO.RemoveItem(_itemCurrent.ItemPrice);
        _inventorySO.AddItem(_itemCurrent);
    }
    public void NextProduct()
    {
        Debug.Log($"{_itemsShop.Length} - {_itemCurrentId}");
        if (_itemsShop.Length <= _itemCurrentId + 1)
            return;
        _productsConteiner.MoveX(-_intervalX);
        ChangeCurrent(_itemCurrentId + 1);
    }
    public void PrevProduct()
    {
        if (0 > _itemCurrentId - 1)
            return;
        _productsConteiner.MoveX(_intervalX);
        ChangeCurrent(_itemCurrentId - 1);
        Debug.Log($"{_itemCurrentId}");
    }
}
