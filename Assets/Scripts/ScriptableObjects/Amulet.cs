using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Amulet", menuName = "Items/new Amulet", order = 51)]
public class Amulet : Items
{
    [SerializeField] private AmuletView _view;
    [SerializeField] private int _damageAmount;
    [SerializeField] private int _damageToPlayer;
    [SerializeField] private int _countUses = -1;
    [SerializeField] private Amulet _amuletAfterAllUses;
    [SerializeField] private Effect _effect;

    public AmuletView View { get => _view; private set => _view = value; }
    public override void Use()
    {
        Debug.Log($"using Amulet {Name}");
    }

}
