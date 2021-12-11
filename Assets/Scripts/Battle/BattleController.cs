using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private InventorySO _inventorySO;
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private ItemSlotBattle[] _itemSlotPotions;
    [SerializeField] private ItemSlotBattle[] _itemSlotAmulets;
    void Start()
    {
        
    }

}
