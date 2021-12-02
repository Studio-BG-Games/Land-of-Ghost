using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DropItem : MonoBehaviour
{
    private SpriteRenderer _sr;
    private Items _item;
    private void OnMouseDown()
    {
        Debug.Log("Pick Up");
    }
    public void Init(Items item)
    {
        _sr = GetComponent<SpriteRenderer>();
        _item = item;
        _sr.sprite = _item.Icon;
    }
}