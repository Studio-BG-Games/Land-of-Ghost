using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class TweenMover : MonoBehaviour
{
    [SerializeField] private float _duration;
    private Tweener _tween;
    public Action OnTweenComplete;
    private void OnDestroy()
    {
        OnTweenComplete = null;
    }
    public void MoveY(float length)
    {
        if (_tween.IsActive())
            return;
        _tween = transform.DOMoveY(transform.position.y + length, _duration).OnComplete(()=>OnTweenComplete?.Invoke());
    }
    
}
