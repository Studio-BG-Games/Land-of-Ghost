using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TweenMover))]
public class LevelsSelectSpawner : MonoBehaviour
{
    [SerializeField] private LevelData[] _levels;
    [SerializeField] private float _intervalY;
    [SerializeField] private LevelSelect _levelPrefab;

    private LevelSelect[] _levelSelects;
    private LevelData _currentLvl;
    private TweenMover _mover;
    private bool _isLvlChanging;
    public Action<LevelData> OnCangeCurrentLvl;
    private void Start()
    {
        _mover = GetComponent<TweenMover>();
        _levelSelects = new LevelSelect[_levels.Length];
        for (int i = 0; i < _levels.Length; i++)
        {
            _levelSelects[i] = Instantiate(_levelPrefab, transform, false);
            var isActive = (i == 0 || _levels[i - 1].IsComplete);
            _levelSelects[i].Initialize(_levels[i], i * _intervalY, isActive);
            if (isActive)
                _currentLvl = _levels[i];
        }
        _mover.OnTweenComplete += OnEndTween;
        OnCangeCurrentLvl?.Invoke(_currentLvl);
        MoveToCurrentLvl();
    }
    public void MoveToCurrentLvl()
    {
        _mover.MoveY(_intervalY * _currentLvl.LvlNumber);
    }
    public void MoveToNext()
    {
        MoveToLvlAtNumber(_currentLvl.LvlNumber);
    }
    public void MoveToPrev()
    {
        MoveToLvlAtNumber(_currentLvl.LvlNumber - 2, -1);
    }
    private void OnEndTween()
    {
        _isLvlChanging = false;
    }
    private void MoveToLvlAtNumber(int number, int direction = 1)
    {
        if (_isLvlChanging)
            return;
        LevelData newCurrentLvl;
        try
        {
            newCurrentLvl = _levels[number];
        }
        catch
        {
            return;
        }
        _currentLvl = newCurrentLvl;
        OnCangeCurrentLvl?.Invoke(_currentLvl);
        _mover.MoveY(direction * _intervalY);
        _isLvlChanging = true;
    }
} 
 