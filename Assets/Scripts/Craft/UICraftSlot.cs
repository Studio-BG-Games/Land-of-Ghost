using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UICraftSlot : UISlot
{
    [SerializeField] private InventorySO _inventorySO;
    private int _itemId;
    private UIDragItem _dragItem;
    public UnityEvent<int> OnItemDrop;

    public void GetChildItem()
    {
        _dragItem = GetComponentInChildren<UIDragItem>();
        if(_dragItem == null)
        {
            OnItemDrop?.Invoke(0);
            return;
        }            
        _dragItem.SetIngredient(true);
        if (_dragItem.TryGetComponent<PotionView>(out var potionView))
        {
            _itemId = potionView.Id;
            OnItemDrop?.Invoke(_itemId);
        }
        else
        {
            if (_dragItem.TryGetComponent<AmuletView>(out var amuletView))
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