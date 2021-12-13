using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesSpawnChannelSO : ScriptableObject
{
    public UnityAction<List<Enemy>, int> OnEnemiesSpawn;

    public void RaiseEvent(List<Enemy> enemies, int money)
    {
        OnEnemiesSpawn?.Invoke(enemies, money);
    }
}
 