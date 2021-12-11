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
    [SerializeField] private HealthController _HPcontroller;
    private List<Enemy> _enemies = new List<Enemy>();
    private Enemy _firstEnemy;
    private void Start()
    {
        Spawn(_levelDataSettings.Enemies.ElementAt(0), _enemyPosition1);
        if(_levelDataSettings.Enemies.Count > 1)
            Spawn(_levelDataSettings.Enemies.ElementAt(1), _enemyPosition2);
        _enemiesSpawnChannel.RaiseEvent(_enemies);
        _firstEnemy = _enemies.ElementAt(0);
        _HPcontroller.Initialize(_firstEnemy.MaxHP, _firstEnemy.CurrentHP);
        _firstEnemy.OnTakeHit += _HPcontroller.OnHealthChange;
        _firstEnemy.OnDeth += _HPcontroller.Hide;
    }
    private void OnEnable()
    {
    }
    private void OnDisable()
    {
        _firstEnemy.OnTakeHit -= _HPcontroller.OnHealthChange;
        _firstEnemy.OnDeth -= _HPcontroller.Hide;
    }
    private void Spawn(Enemy enemy, Transform pos)
    {
        if(enemy != null)
            _enemies.Add(Instantiate(enemy, pos));
    }
    public void TakeHit(int amount)
    {
        _firstEnemy.TakeDamage(amount);
    }
}
