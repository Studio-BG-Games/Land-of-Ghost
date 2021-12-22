using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bottle", menuName = "Items/new Potion", order = 51)]
public class Potion : Items
{
    [Range(0, 100)]
    [SerializeField] private int _damageBoostPercent;
    [SerializeField] private int _damageBoostTurnsCount;
    [Range(0, 100)]
    [SerializeField] private int _defenceBoostPercent;
    [SerializeField] private int _defenceBoostTurnsCount;
    [SerializeField] private int _healAmount;

    public int DamageBoostPercent { get => _damageBoostPercent; set => _damageBoostPercent = value; }
    public int DamageBoostTurnsCount { get => _damageBoostTurnsCount; set => _damageBoostTurnsCount = value; }
    public int DefenceBoostPercent { get => _defenceBoostPercent; set => _defenceBoostPercent = value; }
    public int DefenceBoostTurnsCount { get => _defenceBoostTurnsCount; set => _defenceBoostTurnsCount = value; }
    public int HealAmount { get => _healAmount; set => _healAmount = value; }
}
