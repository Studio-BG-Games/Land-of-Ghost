using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HidePanel : MonoBehaviour
{
    public UnityEvent OnEnter;
    private void OnMouseDown()
    {
        OnEnter?.Invoke();
    }
}
