using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        Transform currentChildItemTransform;
        if (transform.childCount > 0)
        {
            currentChildItemTransform = transform.GetChild(0);
            currentChildItemTransform.SetParent(otherItemTransform.parent);
            currentChildItemTransform.localPosition = Vector3.zero;
        }            
        otherItemTransform.SetParent(transform);
        otherItemTransform.localPosition = Vector3.zero;
    }
}
