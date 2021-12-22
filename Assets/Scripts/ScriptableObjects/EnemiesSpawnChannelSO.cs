using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesSpawnChannelSO : ScriptableObject
{
    public UnityAction<List<Enemy>> OnEnemiesSpawn;

    public void RaiseEvent(List<Enemy> enemies)
    {
        OnEnemiesSpawn?.Invoke(enemies);
    }
}
 