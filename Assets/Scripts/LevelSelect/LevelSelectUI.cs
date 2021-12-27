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
    private void OnDestroy()
    {
        _levelsSelectSpawner.OnCangeCurrentLvl -= RefreshData;
    }
    private void RefreshData(LevelSelect levelSelect)
    {
        _levelDataSettings.SetLevelOrigin(levelSelect.Level);
        if (_levelDataSettings.LvlNumber > 0)
            _levelsDescription.text = $"Рiвень {levelSelect.Level.LvlNumber}\n{levelSelect.Level.Description}";
        else
            _levelsDescription.text = $"{levelSelect.Level.Description}";
    }
    public void StartLevel()
    {
        if(_levelDataSettings.LvlNumber == 0)
            OnLevelChange?.Invoke("TraderHouse");
        else
            OnLevelChange?.Invoke("BattleLevel");
    }
}
