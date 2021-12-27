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
    [SerializeField] private Dialog _dialog;
    private List<Enemy> _enemies = new List<Enemy>();
    private Enemy _firstEnemy; 
    private Enemy _secondEnemy;
    private int _maxHP;
    private int _currentHP;
    public Action<int> OnEnemyDealDamage;
    public Action OnEnemyEndTurn;
    public Action OnEnemyDeath;
    private void Start()
    {
        Spawn(_levelDataSettings.Enemies.ElementAt(0), _enemyPosition1);
        if(_levelDataSettings.Enemies.Count > 1)
            Spawn(_levelDataSettings.Enemies.ElementAt(1), _enemyPosition2);
        _firstEnemy = _enemies.ElementAt(0);
        if(_enemies.Count == 2)_secondEnemy = _enemies.ElementAt(1);
        _enemiesSpawnChannel.RaiseEvent(_enemies);
        _maxHP = _firstEnemy.MaxHP;
        _currentHP = _firstEnemy.CurrentHP;
        if (_secondEnemy != null)
        {
            _secondEnemy.OnTakeHit += OnEnemyTakeHit;
            _secondEnemy.OnDeth += EnemyDeth;
            _secondEnemy.OnDealDamage += OnEnemyDealDamage.Invoke;
            _maxHP += _secondEnemy.MaxHP;
            _currentHP += _secondEnemy.CurrentHP;
        }
        _HPcontroller.Initialize(_maxHP, _currentHP);

        _firstEnemy.OnTakeHit += OnEnemyTakeHit;
        _firstEnemy.OnDeth += EnemyDeth;
        _firstEnemy.OnDealDamage += OnEnemyDealDamage.Invoke;
        _firstEnemy.OnEndTurn += OnEnemyEndTurn.Invoke;
    }
    private void OnDisable()
    {
        StopAllCoroutines();
        OnEnemyDeath = null;
        _firstEnemy.OnTakeHit -= OnEnemyTakeHit;
        _firstEnemy.OnDeth -= EnemyDeth;
    }
    private void Spawn(Enemy enemy, Transform pos)
    {
        if(enemy != null)
            _enemies.Add(Instantiate(enemy, pos));
    }
    private void OnEnemyTakeHit()
    {
        if (_secondEnemy != null)
            _currentHP = _secondEnemy.CurrentHP + _firstEnemy.CurrentHP;
        else
            _currentHP = _firstEnemy.CurrentHP;
        _HPcontroller.OnHealthChange(_currentHP);
        _dialog.TakeDmgDialog();
    }
    public void TakeHitEnemy(int amount)
    {
        StartCoroutine(WaitEndPlayerAttackAnimation(amount));
    }
    public void StartEnemyTurn()
    {
        StartCoroutine(WaitEndPlayerTurn1());
        if(_secondEnemy != null)
            StartCoroutine(WaitEndPlayerTurn2());
    }
    public void EnemyDeth()
    {
        if (_firstEnemy.CurrentHP > 0)
            return;

        _dialog.DeathDialog();
        _HPcontroller.Hide();
        StartCoroutine(WaitLevelExit());
    }
    private IEnumerator WaitEndPlayerAttackAnimation(int amount)
    {
        yield return new WaitForSeconds(1);
        if (_secondEnemy != null && _secondEnemy.CurrentHP > 0)
            _secondEnemy.TakeDamage(amount);
        else
            _firstEnemy.TakeDamage(amount);
    }
    private IEnumerator WaitEndPlayerTurn1()
    {
        yield return new WaitForSeconds(_firstEnemy.TimeDurationAttack + 0.5f);
        _firstEnemy.StartTurn();
    }
    private IEnumerator WaitEndPlayerTurn2()
    {
        yield return new WaitForSeconds(_secondEnemy.TimeDurationAttack);
        _secondEnemy.StartTurn();
    }
    private IEnumerator WaitLevelExit()
    {
        yield return new WaitForSeconds(1);
        _itemsSpawner.PickUpAllDrops();
        _levelDataSettings.Complete();
        OnEnemyDeath?.Invoke();
    }
}
