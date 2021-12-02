using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner: MonoBehaviour
{
    [SerializeField] private DropItem dropItem;
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
        foreach (var enemy in enemies)
        {
            enemy.OnDeth += SpawnItems;
        }
    }

    private void SpawnItems(List<Items> items)
    {
        foreach (var item in items)
        {
            SpawnItem(item);
        }
    }
}
