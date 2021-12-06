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
    private int _currentLvlNumber;
    private TweenMover _mover;
    private bool _isLvlChanging;
    public Action<LevelSelect> OnCangeCurrentLvl;
    private void Awake()
    {
        _mover = GetComponent<TweenMover>();
        _mover.OnTweenComplete += OnEndTween;
    }
    private void Start()
    {
        SpawnLevels();
        OnCangeCurrentLvl?.Invoke(_levelSelects[_currentLvlNumber]);
        MoveToCurrentLvl();
    }

    private void SpawnLevels()
    {
        _levelSelects = new LevelSelect[_levels.Length];
        for (int i = 0; i < _levels.Length; i++)
        {
            _levelSelects[i] = Instantiate(_levelPrefab, transform, false);
            var isActive = (i == 0 || _levels[i - 1].IsComplete);
            _levelSelects[i].Initialize(_levels[i], i * _intervalY, isActive);
            if (isActive)
                _currentLvlNumber = i;
        }
    }

    public void MoveToCurrentLvl()
    {
        _mover.MoveY(_intervalY * (_currentLvlNumber + 1) );
        _levelSelects[_currentLvlNumber].SetCurrent(true);
    }
    public void MoveToNext()
    {
        if(_levelSelects[_currentLvlNumber].Level.IsComplete)
            MoveToLvlAtNumber(_currentLvlNumber + 1);
    }
    public void MoveToPrev()
    {
        MoveToLvlAtNumber(_currentLvlNumber - 1, -1);
    }
    private void OnEndTween()
    {
        _isLvlChanging = false;
    }
    private void MoveToLvlAtNumber(int number, int direction = 1)
    {
        if (_isLvlChanging)
            return;
        LevelSelect newCurrentLvl;
        try
        {
            newCurrentLvl = _levelSelects[number];
        }
        catch
        {
            return;
        }
        _levelSelects[_currentLvlNumber].SetCurrent(false);
        _currentLvlNumber = number;
        OnCangeCurrentLvl?.Invoke(newCurrentLvl);
        _mover.MoveY(direction * _intervalY );
        _isLvlChanging = true;
        newCurrentLvl.SetCurrent(true);
    } 
} 
 