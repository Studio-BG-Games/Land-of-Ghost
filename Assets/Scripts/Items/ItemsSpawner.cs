using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner: MonoBehaviour
{
    [SerializeField] private DropItem dropItem;
    [SerializeField] private EnemiesSpawnChannelSO _enemiesSpawnChannel;
    private List<Enemy> _enemies;
    private void OnEnable()
    {
        _enemiesSpawnChannel.OnEnemiesSpawn += OnEnemySpawn;
    }
    private void OnDisable()
    {
        _enemiesSpawnChannel.OnEnemiesSpawn -= OnEnemySpawn;
        foreach (var enemy in _enemies) 
            enemy.OnDeth -= SpawnItems;
    }
    public void SpawnItem(Items item)
    {
        var amulet = item as Amulet;
        if (amulet != null)
            Instantiate(dropItem, transform).Init(amulet);
        var potion = item as Potion;
        if (potion != null)
            Instantiate(dropItem, transform).Init(potion);
    }
    public void OnEnemySpawn(List<Enemy> enemies)
    {
        _enemies = enemies;
        foreach (var enemy in enemies)
            enemy.OnDeth += SpawnItems;
    }

    private void SpawnItems(List<Items> items)
    {
        foreach (var item in items)
        {
            SpawnItem(item);
        }
    }
}
