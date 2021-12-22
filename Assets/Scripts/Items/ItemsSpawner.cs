using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemsSpawner: MonoBehaviour
{
    [SerializeField] private DropItem dropItem;
    [SerializeField] private EnemiesSpawnChannelSO _enemiesSpawnChannel;
    private List<Enemy> _enemies = new List<Enemy>();
    private List<DropItem> _drops = new List<DropItem>();
    private void OnEnable()
    {
        _enemiesSpawnChannel.OnEnemiesSpawn += OnEnemySpawn;
    }
    private void OnDisable()
    {
        _enemiesSpawnChannel.OnEnemiesSpawn -= OnEnemySpawn;
        foreach (var enemy in _enemies) 
            enemy.OnSpawnDrop -= SpawnItems;
    }
    public void SpawnItem(Items item)
    {
        var drop = Instantiate(dropItem, transform);
        drop.Init(item);
        _drops.Add(drop);
        RandomLocation(drop.transform);
    }
    private void RandomLocation(Transform transform)
    {
        transform.localPosition += new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
    public void SpawnItem(int money)
    {
        var drop = Instantiate(dropItem, transform);
        drop.Init(money);
        _drops.Add(drop);
        RandomLocation(drop.transform);
    }
    public void OnEnemySpawn(List<Enemy> enemies)
    {
        _enemies = enemies;
        foreach (var enemy in enemies)
            enemy.OnSpawnDrop += SpawnItems;
    }
    private void SpawnItems(Dictionary<Items,int> items,int money)
    {
        foreach (var item in items)
        {
            var rnd = Random.Range(0, 100);
            if ( item.Value > rnd )
                SpawnItem(item.Key);
        }
        SpawnItem(money);
    }
    public void PickUpAllDrops()
    {
        foreach (var drop in _drops)
        {
            drop.PickUp();
        }
    }
}
