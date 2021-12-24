using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ItemsChannelSO", menuName = "SO/ItemsChannelSO")]
public class ItemsChannelSO : ScriptableObject
{
    public UnityAction<Items> OnItemsChannel;

    public void RaiseEvent(Items item)
    {
        OnItemsChannel?.Invoke(item);
    }
}
 