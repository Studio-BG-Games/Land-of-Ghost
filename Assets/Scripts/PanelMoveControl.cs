using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TweenMover))]
public class PanelMoveControl : MonoBehaviour
{
    [SerializeField] private Button _buttonForward;
    [SerializeField] private Button _buttonBack;
    [SerializeField] private int _lengthToMove;
    [SerializeField] private bool _moveX;
    [SerializeField] private bool _moveY;
    private TweenMover _mover;
    private bool _isTweening;
    private void Awake()
    {
        _mover = GetComponent<TweenMover>();
        _mover.OnTweenComplete += OnEndTween;
    }
    private void OnDisable()
    {
        _mover.OnTweenComplete -= OnEndTween;
    }
    public void MoveForward()
    {
        if (_isTweening)
            return;
        _isTweening = true;
        if(_moveX)
            _mover.MoveX(_lengthToMove);
        if(_moveY)
            _mover.MoveY(_lengthToMove);
        _buttonForward.gameObject.SetActive(false);
        _buttonBack.gameObject.SetActive(true);
    }
    public void MoveBackward()
    {
        if (_isTweening)
            return;
        _isTweening = true;
        if (_moveX)
            _mover.MoveX(-_lengthToMove);
        if (_moveY)
            _mover.MoveY(-_lengthToMove);
        _buttonForward.gameObject.SetActive(true);
        _buttonBack.gameObject.SetActive(false);
    }
    private void OnEndTween()
    {
        _isTweening = false;
    }
}
