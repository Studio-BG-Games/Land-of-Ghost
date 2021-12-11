using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "VoidChannelSO", menuName = "SO/VoidChannelSO")]
public class VoidChannelSO : ScriptableObject
{
    public UnityAction OnVoid;

    public void RaiseEvent()
    {
        OnVoid?.Invoke();
    }
}
 