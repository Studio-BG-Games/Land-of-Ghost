using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    public UnityEvent<string> OnEndLevel;
    void Start()
    {
        _player.OnDealDamage += DealDamageToEnemy;
        _player.OnEndTurn += StartEnemyTurn;
        _enemySpawner.OnEnemyDealDamage += DealDamageToPlayer;
        _enemySpawner.OnEnemyEndTurn += StartPlayerTurn;
        _enemySpawner.OnEnemyDeath += LevelExit;
    }
    private void OnDisable()
    {
        _player.OnDealDamage -= DealDamageToEnemy;
        _player.OnEndTurn -= StartEnemyTurn;
        _enemySpawner.OnEnemyDealDamage -= DealDamageToPlayer;
        _enemySpawner.OnEnemyEndTurn -= StartPlayerTurn;
        StopAllCoroutines();
    }
    private void DealDamageToEnemy(int amount)
    {
        _enemySpawner.TakeHitEnemy(amount);
    }
    private void DealDamageToPlayer(int amount)
    {
        StartCoroutine(WaitEndEnemyAttackAnimation(amount));
    }
    private void StartEnemyTurn()
    {
        _enemySpawner.StartEnemyTurn();
    }
    private void StartPlayerTurn()
    {
        StartCoroutine(WaitEndEnemyTurn());
    }
    private void LevelExit()
    {
        OnEndLevel?.Invoke("MapMenu");
    }
    private IEnumerator WaitEndEnemyAttackAnimation(int amount)
    {
        yield return new WaitForSeconds(1);
        _player.TakeDamage(amount);
    }
    private IEnumerator WaitEndEnemyTurn()
    {
        yield return new WaitForSeconds(2);
        _player.StartTurn();
    }

}
