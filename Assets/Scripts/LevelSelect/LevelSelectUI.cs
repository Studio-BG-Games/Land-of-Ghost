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
    [SerializeField] private LevelData _levelDataSettings;
    public UnityEvent<string> OnLevelChange;
    private void Awake()
    {
        _levelsSelectSpawner.OnCangeCurrentLvl += RefreshData;
    }
    private void RefreshData(LevelData levelData)
    {
        _levelDataSettings.SetLevelOrigin(levelData);
        _levelsDescription.text = $"Уровень {levelData.LvlNumber}\n{levelData.Description}";
    }
    public void StartLevel()
    {
        OnLevelChange?.Invoke("BattleLevel");
    }
}
