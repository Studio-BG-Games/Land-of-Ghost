using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIDragItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    private bool _isCrafted;
    private bool _isIngredient;
    public UnityEvent<Items> OnCraftItem;
    public UnityEvent OnCraftClear;
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var slotTransform = _rectTransform.parent;
        slotTransform.SetAsLastSibling();
        _canvasGroup.blocksRaycasts = false;
        CheckCrafted();
        CheckisIngredient();
    }

    private void CheckisIngredient()
    {
        if (!_isIngredient)
            return;
        var craftSlot = transform.parent.GetComponent<UICraftSlot>();
        craftSlot.Zeroing();
        SetIngredient(false);
    }

    private void CheckCrafted()
    {
        if (!_isCrafted)
            return;
        foreach (var slot in FindObjectsOfType<UICraftSlot>())
        {
            slot.Craft();
        }
        var newItem = transform.parent.GetComponent<UICraftResultSlot>().NewItem;
        OnCraftClear?.Invoke();
        OnCraftItem?.Invoke(newItem);
        SetCrafted(false);        
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        _canvasGroup.blocksRaycasts = true;
    }
    public void SetCrafted(bool crafted)
    {
        _isCrafted = crafted;
    }
    public void SetIngredient(bool isIngredient)
    {
        _isIngredient = isIngredient;
    }
}
