using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CraftReciepts", menuName = "SO/CraftReciepts")]
public class CraftReciepts : ScriptableObject
{
    private Dictionary<HashSet<int>,int> _craftMap = new Dictionary<HashSet<int>, int>
    {
        { new HashSet<int>{9,13}, 21 },
        { new HashSet<int>{24,13}, 14 },
        { new HashSet<int>{21,6}, 5 },
        { new HashSet<int>{20,7}, 8 },
        { new HashSet<int>{5,11}, 8 },
        { new HashSet<int>{9,7}, 23 },
    };
    public Dictionary<HashSet<int>, int> CraftMap { get => _craftMap; private set => _craftMap = value; }
}