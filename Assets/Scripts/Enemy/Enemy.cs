using DragonBones;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour, IBattleble
{
    [SerializeField] private UnityArmatureComponent _armature;
    [SerializeField] private SpriteRenderer _shadow;
    [SerializeField] private Effects _effectsConteiner;
    [SerializeField] private List<Items> _itemsDrop;
    [Range(0, 100)]
    [SerializeField] private List<int> _itemsDropChance;
    [SerializeField] private int _maxHP;
    [SerializeField] private int _attackDamage;
    [SerializeField] private string _animationStand;
    [SerializeField] private string _animationAttack;
    [SerializeField] private string _animationTakeHit;
    [SerializeField] private string _animationDeath;
    [SerializeField] private int _moneyDrop;
    [SerializeField] private float _timeDurationAttack = 3f; 
    private int _currentHP;
    private bool _isAlive;
    private List<Effect> _effects;
    private Dictionary<Items, int> _itemsDropMap = new Dictionary<Items, int>();
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
    public int MaxHP => _maxHP;
    public int CurrentHP => _currentHP;
    public int MoneyDrop => _moneyDrop;
    public Action<Dictionary<Items, int>, int> OnSpawnDrop;
    public Action OnTakeHit;
    public Action<int> OnDealDamage;
    public Action OnDeth;
    public Action OnEndTurn;
    public List<Effect> Effects => throw new NotImplementedException();
    public bool MyTurn => throw new NotImplementedException();
    public float TimeDurationAttack { get => _timeDurationAttack; set => _timeDurationAttack = value; }    
    private void Awake()
    {
        _currentHP = _maxHP;
    }
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

        foreach (var item in _itemsDrop)
        {
            _itemsDropMap.Add(item, _itemsDropChance.ElementAt(_itemsDropMap.Count));
        }
        StartCoroutine(WaitAnimationEnd());
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
        if (_shadow != null) _shadow.enabled = false;
        _isAlive = false;
        OnSpawnDrop?.Invoke(_itemsDropMap, _moneyDrop);
        OnDeth?.Invoke();
    }
    public void TakeDamage(int amount, bool animate = true)
    {
        if (!_isAlive)
            return;
        _currentHP -= amount;
        if (_currentHP <= 0)
            StartCoroutine(WaitDeth());
        if (animate)_armature.animation.GotoAndPlayByProgress(_animationMap[anim.takehit], 0, 1);
        OnTakeHit?.Invoke();
    }
    public void StartTurn()
    {
        if (!_isAlive)
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
    private IEnumerator WaitAnimationEnd()
    {
        while (true)
        {
            if (_armature.animation.isCompleted && _armature.animation.lastAnimationName != _animationMap[anim.death])
                _armature.animation.GotoAndPlayByProgress(_animationMap[anim.stand], 0, -1);
            yield return null;
        }
    }
    private IEnumerator WaitDeth()
    {
        _currentHP = 0;
        yield return new WaitForSeconds(0.5f); 
        Death();
    }
}
