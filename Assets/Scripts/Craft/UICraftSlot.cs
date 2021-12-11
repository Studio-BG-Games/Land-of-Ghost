using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UICraftSlot : UISlot, IDropHandler
{
    [SerializeField] private InventorySO _inventorySO;
    private int _itemId;
    private UIDragItem _dragItem;
    public UnityEvent<int> OnItemDrop;

    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        _dragItem = otherItemTransform.GetComponent<UIDragItem>();
        _dragItem.SetIngredient(true);
        if (otherItemTransform.TryGetComponent<PotionView>(out var potionView))
        {
            _itemId = potionView.Id;
            OnItemDrop?.Invoke(_itemId);
        }
        else
        {
            if (otherItemTransform.TryGetComponent<AmuletView>(out var amuletView))
            {
                _itemId = amuletView.Id;
                OnItemDrop?.Invoke(_itemId);
            }
        }
    }
    public void Craft()
    {
        _inventorySO.RemoveItem(_itemId);
    }
    public void Zeroing()
    {
        _itemId = 0;
        OnItemDrop?.Invoke(_itemId);
    }
}