using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "StringChannelSO", menuName = "SO/StringChannelSO")]
public class StringChannelSO : ScriptableObject
{
    public UnityAction<string> OnStringChannel;

    public void RaiseEvent(string str)
    {
        OnStringChannel?.Invoke(str);
    }
}
 