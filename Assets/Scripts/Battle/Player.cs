using DragonBones;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IBattleble
{
    [SerializeField] private HealthController _HPcontroller;
    [SerializeField] private UnityArmatureComponent _armature;
    [SerializeField] private Effects _effectsConteiner;
    [SerializeField] private int _maxHP;
    [SerializeField] private int _currentHP;
    [SerializeField] private Amulet _currentUsedInBatleAmulet;
    [SerializeField] private Potion _currentUsedInBatlePotion;
    [SerializeField] private VoidChannelSO _OnUseAmulet;
    [SerializeField] private VoidChannelSO _OnUsePotion;
    private int _damageBoostPercent;
    private int _damageBoostTurnsCount;
    private int _defenceBoostPercent;
    private int _defenceBoostTurnsCount;
    private Coroutine _turnTimer;
    private bool _myTurn;
    public Action<int> OnUsePotion;
    public Action OnDeth;
    public Action OnEndTurn;
    public Action<int> OnDealDamage;

    public int CurrentHP => _currentHP;
    public List<Effect> _effects => throw new System.NotImplementedException();
    public int MaxHP => _maxHP;

    public List<Effect> Effects => _effects;

    public bool MyTurn => _myTurn;

    private Dictionary<int, string> _animations;
    private void Start()
    {
        Debug.Log(_myTurn);
        _animations = new Dictionary<int, string>();
        _animations.Add(1, "stan"); // idle
        _animations.Add(2, "stan1");
        _animations.Add(3, "atackknigka"); //книга
        _animations.Add(4, "atack0");//руками
        _animations.Add(5, "atack1");//стандартная
        _animations.Add(6, "atack4");//камень
        _animations.Add(7, "demeg"); // take dmg
        _animations.Add(8, "deat"); // death
        _animations.Add(9, "deat2"); 
        _animations.Add(10, "deat3"); 
        _animations.Add(11, "upstan"); 
        _animations.Add(12, "deatStan"); 
        _animations.Add(13, "use");//potions
        _animations.Add(14, "atackknigka2"); //книга

        _HPcontroller.Initialize(_maxHP,_currentHP);
        _OnUseAmulet.OnVoid += UseAmulet;
        _OnUsePotion.OnVoid += UsePotion;
        StartTurn();
        StartCoroutine(WaitAnimationEnd());

    }
    private void OnDestroy()
    {
        StopAllCoroutines();
        _OnUseAmulet.OnVoid -= UseAmulet;
        _OnUsePotion.OnVoid -= UsePotion;
        OnUsePotion = null;
        OnDeth = null;
        OnEndTurn = null;
        OnDealDamage = null;
    }
    public void StartTurn()
    {
        _myTurn = true;
        _turnTimer = StartCoroutine(TurnTimer());
    }
    public void DealDamage()
    {
        var damage = _currentUsedInBatleAmulet.DamageAmount;
        if (_damageBoostTurnsCount > 0)
        {
            damage += damage * _damageBoostPercent / 100;
            _damageBoostTurnsCount--;
        }
        OnDealDamage?.Invoke(damage);
    }
    public void UsePotion()
    {
        if (!_myTurn)
            return;
        var anim = _animations[13];
        _armature.animation.GotoAndPlayByProgress(anim, 0, 1);
        _damageBoostPercent = _currentUsedInBatlePotion.DamageBoostPercent;
        _damageBoostTurnsCount = _currentUsedInBatlePotion.DamageBoostTurnsCount;
        _defenceBoostPercent = _currentUsedInBatlePotion.DefenceBoostPercent;
        _defenceBoostTurnsCount = _currentUsedInBatlePotion.DefenceBoostTurnsCount;
        Heal();
        OnUsePotion?.Invoke(_currentUsedInBatlePotion.Id);
    }

    private void Heal()
    {
        if (_currentHP + _currentUsedInBatlePotion.HealAmount > _maxHP)
            _currentHP = _maxHP;
        else
            _currentHP += _currentUsedInBatlePotion.HealAmount;
        _HPcontroller.OnHealthChange(_currentHP);
    }

    public void UseAmulet()
    {
        if (!_myTurn)
            return;
        var anim = _animations[4];
        if (_currentUsedInBatleAmulet.AnimationId != 0)
            anim = _animations[_currentUsedInBatleAmulet.AnimationId];
        _armature.animation.GotoAndPlayByProgress(anim, 0, 1);

        if (_currentUsedInBatleAmulet.DamageToPlayer > 0)
            TakeDamage(_currentUsedInBatleAmulet.DamageToPlayer, false);
        if (_currentUsedInBatleAmulet.DamageAmount > 0)
            DealDamage();
        _currentUsedInBatleAmulet.CountUses--;
        EndTurn();
    }
    private void EndTurn()
    {
        _myTurn = false;
        StopCoroutine(_turnTimer);
        OnEndTurn?.Invoke();
    }
    public void TakeDamage(int amount, bool animate = true)
    {
        var damage = amount;
        if (_defenceBoostTurnsCount > 0)
        {
            damage -= damage * _defenceBoostPercent / 100;
            _defenceBoostTurnsCount--;
        }
        _currentHP -= damage;
        if (_currentHP <= 0)
            Death();
        else
        {
            _HPcontroller.OnHealthChange(_currentHP);
            if (animate) _armature.animation.GotoAndPlayByProgress(_animations[7], 0, 1);
        }
    }
    public void Death()
    {
        var anim = _animations[8];
        _armature.animation.GotoAndPlayByProgress(anim, 0, 1);
        _effectsConteiner.gameObject.SetActive(false);
        _HPcontroller.Hide();
        OnDeth?.Invoke();
    }    
    private IEnumerator WaitAnimationEnd()
    {
        while (true)
        {
            if (_armature.animation.isCompleted)
                _armature.animation.GotoAndPlayByProgress(_animations[1],0,-1);
            yield return null;
        }
    }
    private IEnumerator TurnTimer()
    {
        float f = 0.0f; 
        while (f < 6.0f)
        {
            yield return new WaitForSeconds(1.0f);
            f = f + 1.0f;
        }
        _myTurn = false;
        OnEndTurn?.Invoke();
        yield return null;
    }
    public void ClearEffect(Effect effect)
    {
        throw new System.NotImplementedException();
    }

    public void SetEffect(Effect effect)
    {
        throw new System.NotImplementedException();
    }

}
