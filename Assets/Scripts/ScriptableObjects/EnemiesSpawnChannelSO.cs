using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "EnemiesSpawnChannelSO", menuName = "ChannelSO/EnemiesSpawn")]
public class EnemiesSpawnChannelSO : ScriptableObject
{
    public UnityAction<List<Enemy>> OnEnemiesSpawn;

    public void RaiseEvent(List<Enemy> enemies)
    {
        OnEnemiesSpawn?.Invoke(enemies);
    }
}
 