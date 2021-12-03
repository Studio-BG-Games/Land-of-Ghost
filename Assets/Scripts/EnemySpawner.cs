using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private LevelData _levelDataSettings;
    [SerializeField] private Transform _enemyPosition1;
    [SerializeField] private Transform _enemyPosition2;
    [SerializeField] private EnemiesSpawnChannelSO _enemiesSpawnChannel;
    private List<Enemy> _enemies = new List<Enemy>();
    private void Start()
    {
        Spawn(_levelDataSettings.Enemies.ElementAt(0), _enemyPosition1);
        if(_levelDataSettings.Enemies.Count > 1)
            Spawn(_levelDataSettings.Enemies.ElementAt(1), _enemyPosition2);
        _enemiesSpawnChannel.RaiseEvent(_enemies);
    }

    private void Spawn(Enemy enemy, Transform pos)
    {
        if(enemy != null)
            _enemies.Add(Instantiate(enemy, pos));
    }
}
