using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ItemsView<T> : MonoBehaviour where T:Items
{
    [SerializeField] protected Image _image;
    [SerializeField] protected T _item;
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
    public void Init(T item)
    {
        _item = item;
        _image.sprite = _item.Icon;
    }

}
