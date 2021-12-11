using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private BattleInventory _battleInventory;
    void Start()
    {
        _player.OnDealDamage += DealDamageToEnemy;
    }

    private void DealDamageToEnemy(int amount)
    {
        _enemySpawner.TakeHit(amount);
    }
}
