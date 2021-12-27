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
    private int _itemsCount;
    private List<Items> _itemsShopActive = new List<Items>();
    void Start()
    {
        _inventorySO.OnMoneyChange += DisplayMoney;
        Refresh();
    }
    public void Refresh()
    {
        Clear();
        CreateProducts();
        ChangeCurrent(0);
        DisplayMoney();
    }
    private void ChangeCurrent(int id)
    {
        _itemCurrent = null;
        _itemCurrentId = -1;
        if (_itemsShopActive.Count == 0)
            return;
        _itemCurrentId = id;
        _itemCurrent = _itemsShopActive[_itemCurrentId];
    }
    private void DisplayMoney()
    {
        _playerMoneyText.text = $"- {_inventorySO.Money}";
    }
    private void CreateProducts()
    {
        _itemsShopActive = new List<Items>();
        for (int i = 0; i < _itemsShop.Length; i++)
        {
            if (!_inventorySO.AmuletsInSlot.Contains(_itemsShop[i]) && !_inventorySO.GetAmulets().Contains(_itemsShop[i]))
            {
                var product = Instantiate(_productPrefab, _productsConteiner.transform);
                product.Init(_itemsShop[i]);
                _itemsShopActive.Add(_itemsShop[i]);
                _itemsCount++;
            }
        }
    }

    private void Clear()
    {
        _productsConteiner.transform.localPosition = new Vector3(0, 0);
        for (var i = _productsConteiner.transform.childCount; i > 0; i--)
        {
            Destroy(_productsConteiner.transform.GetChild(i - 1).gameObject);
        }
    }

    public void BuyProduct()
    {
        if (_itemCurrent == null)
            return;
        if (_inventorySO.Money < _itemCurrent.MoneyPrice)
            return;
        if (_itemCurrent.ItemPrice != null && !_inventorySO.HaveItem(_itemCurrent.ItemPrice))
            return;
        _inventorySO.RemoveMoney(_itemCurrent.MoneyPrice);
        if(_itemCurrent.ItemPrice != null) _inventorySO.RemoveItem(_itemCurrent.ItemPrice);
        _inventorySO.AddItem(_itemCurrent);
        Refresh();
    }
    public void NextProduct()
    {
        if (_itemsCount <= _itemCurrentId + 1)
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
    }
}
