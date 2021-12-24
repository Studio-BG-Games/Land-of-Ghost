using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ItemsView: MonoBehaviour
{
    [SerializeField] protected Image _image;
    [SerializeField] protected Items _item;
    [SerializeField] private TextMeshProUGUI _amountText;
    protected int _amount;
    protected BoxCollider2D _collider;
    protected UIDragItem _dragItem;
    public UnityEvent<string> OnItemClick;
    public int Id => _item.Id;
    public int Amount => _amount;
    private void Start()
    {
        if (_item == null)
            return;
        _image.sprite = _item.Icon;
    }
    private void OnMouseDown()
    {
        MouseDown();
    }
    public void Init(Items item)
    {
        BaseInint(item);
    }
    public void Init(Items item, int amount)
    {
        BaseInint(item);
        ChangeAmount(amount);
    }
    public void ChangeAmount(int amount)
    {
        _amount = amount;
        if (amount > 0 && _amountText != null)
            _amountText.text = amount.ToString();
    }
    protected void MouseDown()
    {
        OnItemClick?.Invoke(_item.Name);
    }
    private void BaseInint(Items item)
    {
        _collider = GetComponent<BoxCollider2D>();
        _dragItem = GetComponent<UIDragItem>();
        _item = item;
        _image.sprite = _item.Icon;
    }

    public void EnableCollider(bool enable)
    {
        _collider.enabled = enable;
    }
    public void EnableDragItem(bool enable)
    {
        _dragItem.enabled = enable;
    }

}
