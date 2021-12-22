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
    public void MoveY(float length, bool isRelative = false)
    {
        if (_tween.IsActive())
            return;
        _tween = transform.DOMoveY(transform.position.y + length, _duration).OnComplete(()=>OnTweenComplete?.Invoke());
        if (isRelative) _tween.SetRelative();
    }
    public void MoveX(float length,bool isRelative = false)
    {
        if (_tween.IsActive())
            return;
        _tween = transform.DOMoveX(transform.position.x + length, _duration).OnComplete(()=>OnTweenComplete?.Invoke());
        if (isRelative) _tween.SetRelative();
    }
    public void Scale(float scale)
    {
        _tween = transform.DOScale(scale, _duration);
    }
    public void ScaleX(float scale)
    {
        _tween = transform.DOScaleX(scale, _duration);
    }
    
}
