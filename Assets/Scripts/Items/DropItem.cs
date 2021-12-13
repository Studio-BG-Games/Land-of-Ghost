using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DropItem : MonoBehaviour
{
    [SerializeField] private InventorySO _inventorySO;
    [SerializeField] private Sprite _moneyIcon;
    private SpriteRenderer _sr;
    private Items _item;
    private int _money;
    private void OnMouseDown()
    {
        PickUp();
    }
    public void PickUp()
    {
        if (_item == null)
            _inventorySO.AddMoney(_money);
        else
            _inventorySO.AddItem(_item);

        gameObject.SetActive(false);
    }
    public void Init(Items item)
    {
        _sr = GetComponent<SpriteRenderer>();
        _item = item;
        _sr.sprite = _item.Icon;
    }
    public void Init(int money)
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.sprite = _moneyIcon;
        _money = money;
    }
}