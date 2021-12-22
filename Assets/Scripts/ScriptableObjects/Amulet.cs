using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Amulet", menuName = "Items/new Amulet", order = 51)]
public class Amulet : Items
{
    [SerializeField] private int _damageAmount;
    [SerializeField] private int _damageToPlayer;
    [SerializeField] private int _countUses = -1;
    [SerializeField] private Amulet _amuletAfterAllUses;
    [SerializeField] private Effect _effect;
    [SerializeField] private int _animationId;

    public int DamageAmount { get => _damageAmount; set => _damageAmount = value; }
    public int DamageToPlayer { get => _damageToPlayer; set => _damageToPlayer = value; }
    public int CountUses { get => _countUses; set => _countUses = value; }
    public Amulet AmuletAfterAllUses { get => _amuletAfterAllUses; set => _amuletAfterAllUses = value; }
    public Effect Effect { get => _effect; set => _effect = value; }
    public int AnimationId { get => _animationId; set => _animationId = value; }


}
