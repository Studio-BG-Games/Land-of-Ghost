using DragonBones;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IBattleble
{
    [SerializeField] private UnityArmatureComponent _armature;
    [SerializeField] private Effects _effectsConteiner;
    [SerializeField] private List<Items> _items;
    [SerializeField] private int _maxHP;
    [SerializeField] private int _currentHP;
    [SerializeField] private int _attackDamage;
    [SerializeField] private string _animationStand;
    [SerializeField] private string _animationAttack;
    [SerializeField] private string _animationTakeHit;
    [SerializeField] private string _animationDeath;
    [SerializeField] private int _moneyDrop;
    [SerializeField] private SpriteRenderer _shadow;
    private bool _myTurn;
    private bool _isAlive;
    private List<Effect> _effects;
    private enum anim
    {
        stand,
        attack,
        takehit,
        death
    }
    private Dictionary<anim, string> _animationMap = new Dictionary<anim, string>
    {
        { anim.stand , "stan" },
        { anim.attack , "atack" },
        { anim.takehit , "demeg" },
        { anim.death , "deat" },
    };
    public Action<List<Items>,int> OnSpawnDrop;
    public Action<int> OnTakeHit;
    public Action<int> OnDealDamage;
    public Action OnDeth;
    public Action OnEndTurn;

    public int MaxHP => _maxHP;
    public int CurrentHP => _currentHP;
    public int MoneyDrop => _moneyDrop;


    public List<Effect> Effects => throw new NotImplementedException();

    public bool MyTurn => throw new NotImplementedException();
    private void Start()
    {
        _isAlive = true;
        if (_animationStand != "")
            _animationMap[anim.stand] = _animationStand;
        if (_animationAttack != "")
            _animationMap[anim.attack] = _animationAttack;
        if (_animationTakeHit != "")
            _animationMap[anim.takehit] = _animationTakeHit;
        if (_animationDeath != "")
            _animationMap[anim.death] = _animationDeath;
    }
    private void OnDisable()
    {
        OnSpawnDrop = null;
        OnTakeHit = null;
        OnDealDamage = null;
        OnDeth = null;
        OnEndTurn = null;
    }
    public void DealDamage()
    {
        _armature.animation.GotoAndPlayByProgress(_animationMap[anim.attack], 0, 1);
        OnDealDamage?.Invoke(_attackDamage);
    }
    public void Death()
    {
        _effectsConteiner.gameObject.SetActive(false);
        _armature.animation.GotoAndPlayByProgress(_animationMap[anim.death], 0, 1);
        if(_shadow != null)_shadow.enabled = false;
        _isAlive = false;
        OnSpawnDrop?.Invoke(_items,_moneyDrop);
        OnDeth?.Invoke();
    }
    public void TakeDamage(int amount)
    {
        if (!_isAlive)
            return;
        _currentHP -= amount;
        if (_currentHP <= 0)
            Death();
        else
        {
            _armature.animation.GotoAndPlayByProgress(_animationMap[anim.takehit], 0, 1);
            OnTakeHit?.Invoke(_currentHP);
        }
    }
    public void StartTurn()
    {
        if ( !_isAlive )
            return;
        DealDamage();
        OnEndTurn?.Invoke();
    }
    public void SetEffect(Effect effect)
    {
        throw new System.NotImplementedException();
    }
    public void ClearEffect(Effect effect)
    {
        throw new System.NotImplementedException();
    }
}
