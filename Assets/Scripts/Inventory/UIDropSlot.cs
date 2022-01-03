using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIDropSlot : UISlot, IDropHandler
{
    public UnityEvent OnSomeItemDrop;
    public UnityEvent OnEqualItemDrop;
    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        Transform currentChildItemTransform;
        var otherItemView = otherItemTransform.GetComponent<ItemsView>();
        if (otherItemView == null) return;
        if (transform.childCount > 0)
        {
            currentChildItemTransform = transform.GetChild(0);
            var currentChildView = currentChildItemTransform.GetComponent<ItemsView>();
            otherItemTransform.GetComponent<ItemsView>();
            var amulet = otherItemTransform.GetComponent<AmuletView>() != null;
            if (otherItemView.Id == currentChildView.Id && !amulet)
            {
                OnEqualItemDrop?.Invoke();
                currentChildView.ChangeAmount(currentChildView.Amount + otherItemView.Amount);
                Destroy(otherItemView.gameObject);
            }
            else
            {
                if (otherItemTransform.parent.childCount > 1)
                {
                    var itemViewFromOtherSlot = otherItemTransform.parent.GetChild(0).GetComponent<ItemsView>();
                    itemViewFromOtherSlot.ChangeAmount(itemViewFromOtherSlot.Amount + otherItemView.Amount);
                    Destroy(otherItemView.gameObject);
                }
                else
                {
                    currentChildItemTransform.SetParent(otherItemTransform.parent);
                    currentChildItemTransform.localPosition = Vector3.zero;
                    otherItemTransform.SetParent(transform);
                    otherItemTransform.localPosition = Vector3.zero;
                } 
            }
        }
        else
        {
            otherItemTransform.SetParent(transform);
            otherItemTransform.localPosition = Vector3.zero;
        }
        OnSomeItemDrop?.Invoke();
    }
}
