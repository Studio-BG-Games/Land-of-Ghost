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
    public List<Enemy> Enemies;
    public UnityEvent<List<Enemy>> OnEnemySpawn;
    private void Start()
    {
        Spawn(_levelDataSettings.Enemies.ElementAt(0), _enemyPosition1);
        Spawn(_levelDataSettings.Enemies.ElementAt(1), _enemyPosition2);
        OnEnemySpawn?.Invoke(Enemies);
    }

    private void Spawn(Enemy enemy, Transform pos)
    {
        Enemies.Add(Instantiate(enemy, pos));
    }
}
