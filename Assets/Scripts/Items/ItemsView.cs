using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ItemsView<T> : MonoBehaviour where T:Items
{
    [SerializeField] protected Image _image;
    [SerializeField] protected T _item;
    protected BoxCollider2D _collider;
    protected UIDragItem _dragItem;
    public int Id => _item.Id;
    private void Start()
    {
        if (_item == null)
            return;
        _image.sprite = _item.Icon;
    }
    private void OnMouseDown()
    {
        _item.Use();
    }
    public virtual void Init(T item, int amount = 1 )
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
