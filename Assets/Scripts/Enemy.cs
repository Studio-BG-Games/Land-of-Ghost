using DragonBones;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour, IBattleble
{
    [SerializeField] private UnityArmatureComponent _armature;
    [SerializeField] private Effects _effectsConteiner;
    [SerializeField] private List<Items> _items;
    public Action<List<Items>> OnDeth;
    public int _maxHP => throw new System.NotImplementedException();

    public int _currentHP => throw new System.NotImplementedException();

    public List<Effect> _effects => throw new System.NotImplementedException();

    public bool _myTurn => throw new System.NotImplementedException();
    private void OnMouseDown()
    {
        Death();
    }
    public void ClearEffect(Effect effect)
    {
        throw new System.NotImplementedException();
    }

    public int DealDamage()
    {
        throw new System.NotImplementedException();
    }

    public void Death()
    {
        _effectsConteiner.gameObject.SetActive(false);
        _armature.animation.GotoAndPlayByProgress("Deat", 0, 1);
        OnDeth?.Invoke(_items);
    }

    public void SetEffect(Effect effect)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        throw new System.NotImplementedException();
    }
}
