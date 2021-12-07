using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIAmuletSlot : MonoBehaviour
{
    [SerializeField] private int _idSlot;
    public UnityEvent<int> OnAmuletSlotClick;
    private void OnMouseDown()
    {
        OnAmuletSlotClick?.Invoke(_idSlot);
    }
}
