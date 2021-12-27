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
    public UnityEvent OnCraftClear;
    public UnityEvent<GameObject> OnBeginDragEvent;
    public UnityEvent<GameObject> OnEndDragNowereEvent;
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvas = GetComponentInParent<Canvas>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        OnBeginDragEvent?.Invoke(gameObject);
        gameObject.transform.SetAsLastSibling();
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
        if(craftSlot != null)
            craftSlot.Zeroing();
        SetIngredient(false);
    }
    private void CheckCrafted()
    {
        if (!_isCrafted)
            return;
        OnCraftClear?.Invoke();
        SetCrafted(false);        
    }
    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if(transform.parent.childCount == 1 || transform.GetComponent<AmuletView>() != null)
        {
            transform.localPosition = Vector3.zero;
        }
        else
        {
            OnEndDragNowereEvent?.Invoke(gameObject);
        }
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
