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
    [SerializeField] private ItemsSpawner _itemsSpawner;
    private List<Enemy> _enemies = new List<Enemy>();
    private Enemy _firstEnemy; 
    public Action<int> OnEnemyDealDamage;
    public Action OnEnemyEndTurn;
    public Action OnEnemyDeath;
    private void Start()
    {
        Spawn(_levelDataSettings.Enemies.ElementAt(0), _enemyPosition1);
        if(_levelDataSettings.Enemies.Count > 1)
            Spawn(_levelDataSettings.Enemies.ElementAt(1), _enemyPosition2);
        _firstEnemy = _enemies.ElementAt(0);
        _enemiesSpawnChannel.RaiseEvent(_enemies, _firstEnemy.MoneyDrop);
        _HPcontroller.Initialize(_firstEnemy.MaxHP, _firstEnemy.CurrentHP);

        _firstEnemy.OnTakeHit += _HPcontroller.OnHealthChange;
        _firstEnemy.OnDeth += EnemyDeth;
        _firstEnemy.OnDealDamage += OnEnemyDealDamage.Invoke;
        _firstEnemy.OnEndTurn += OnEnemyEndTurn.Invoke;
    }
    private void OnDisable()
    {
        StopAllCoroutines();
        OnEnemyDeath = null;
    }
    private void Spawn(Enemy enemy, Transform pos)
    {
        if(enemy != null)
            _enemies.Add(Instantiate(enemy, pos));
    }
    public void TakeHitEnemy(int amount)
    {
        StartCoroutine(WaitEndPlayerAttackAnimation(amount));
    }
    public void StartEnemyTurn()
    {
        StartCoroutine(WaitEndPlayerTurn());
    }
    public void EnemyDeth()
    {
        _HPcontroller.Hide();
        StartCoroutine(WaitLevelExit());
    }
    private IEnumerator WaitEndPlayerAttackAnimation(int amount)
    {
        yield return new WaitForSeconds(1);
        _firstEnemy.TakeDamage(amount);
    }
    private IEnumerator WaitEndPlayerTurn()
    {
        yield return new WaitForSeconds(3);
        _firstEnemy.StartTurn();
    }
    private IEnumerator WaitLevelExit()
    {
        yield return new WaitForSeconds(2);
        _itemsSpawner.PickUpAllDrops();
        _levelDataSettings.Complete();
        OnEnemyDeath?.Invoke();
    }
}
