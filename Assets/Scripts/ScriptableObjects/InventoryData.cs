using System.Collections.Generic;
using UnityEngine;

public class InventoryData: ScriptableObject
{
    [SerializeField] private int[] _items;
    [SerializeField] private int[] _amuletsInSlot;
    [SerializeField] private int[] _potionsInSlot;
    [SerializeField] private int _money;
}
