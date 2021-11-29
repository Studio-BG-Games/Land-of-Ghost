using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemsView<T> : MonoBehaviour where T:Items
{
    [SerializeField] protected Image _image;
    [SerializeField] protected T _item;
    private void Start()
    {
        _image.sprite = _item.Icon;
    }
    private void OnMouseDown()
    {
        _item.Use();
    }
}
