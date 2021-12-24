using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameObjectChannelSO", menuName = "SO/GameObjectChannelSO")]
public class GameObjectChannelSO : ScriptableObject
{
    public UnityAction<GameObject> OnGameObjectChannel;

    public void RaiseEvent(GameObject obj)
    {
        OnGameObjectChannel?.Invoke(obj);
    }
}
 