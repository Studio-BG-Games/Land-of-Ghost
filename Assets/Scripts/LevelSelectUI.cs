using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class LevelSelectUI : MonoBehaviour
{
    [SerializeField] private LevelsSelectSpawner _levelsSelectSpawner;
    [SerializeField] private TextMeshProUGUI _levelsDescription;
    private LevelData _focusedlevelData;
    public UnityEvent<string> OnLevelChenge;
    private void Awake()
    {
        _levelsSelectSpawner.OnCangeCurrentLvl += RefreshData;
    }
    private void RefreshData(LevelData levelData)
    {
        _focusedlevelData = levelData;
        _levelsDescription.text = $"Уровень {levelData.LvlNumber}\n{levelData.Description}";
    }
    public void StartLevel()
    {
        OnLevelChenge?.Invoke(_focusedlevelData.SceneName);
    }
}
