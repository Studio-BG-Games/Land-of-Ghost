using DragonBones;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour, IBattleble
{
    [SerializeField] private HealthController _HPcontroller;
    [SerializeField] private UnityArmatureComponent _armature;
    [SerializeField] private Effects _effectsConteiner;
    [SerializeField] private int _maxHP;
    [SerializeField] private int _currentHP;
    [SerializeField] private Amulet _currentUsedInBatleAmulet;
    [SerializeField] private VoidChannelSO _OnUseAmulet;
    private bool _myTurn;
    public Action OnDeth;
    public Action OnEndTurn;
    public Action<int> OnDealDamage;

    public int CurrentHP => _currentHP;
    public List<Effect> _effects => throw new System.NotImplementedException();
    public int MaxHP => _maxHP;

    public List<Effect> Effects => _effects;

    public bool MyTurn => _myTurn;

    private Dictionary<int, string> _animations = new Dictionary<int, string>(7);
    private void Start()
    {
        _animations.Add(1, "stan"); // idle
        _animations.Add(2, "stan0");
        _animations.Add(3, "atack"); //книга
        _animations.Add(4, "atack0");//руками
        _animations.Add(5, "atack1");//стандартная
        _animations.Add(6, "atack4");//камень
        _animations.Add(7, "demeg"); // take dmg

        _HPcontroller.Initialize(_maxHP,_currentHP);
        _OnUseAmulet.OnVoid += UseAmulet;
        StartTurn();
    }
    public void StartTurn()
    {
        _myTurn = true;
    }
    public void DealDamage()
    {
        StartCoroutine(WaitAnimationEnd());
        OnDealDamage?.Invoke(_currentUsedInBatleAmulet.DamageAmount);
    }
    public void UseAmulet()
    {
        if ( !_myTurn )
            return;
        var anim = _animations[4];
        if (_currentUsedInBatleAmulet.AnimationId != 0)
            anim = _animations[_currentUsedInBatleAmulet.AnimationId];
        _armature.animation.GotoAndPlayByProgress(anim, 0, 1);

        if (_currentUsedInBatleAmulet.DamageToPlayer > 0 )
            TakeDamage(_currentUsedInBatleAmulet.DamageToPlayer);
        if (_currentUsedInBatleAmulet.DamageAmount > 0)
            DealDamage();
        _myTurn = false;
        OnEndTurn?.Invoke();
    }
    public void TakeDamage(int amount)
    {
        _currentHP -= amount;
        if (_currentHP <= 0)
            Death();
        else
        {
            _HPcontroller.OnHealthChange(_currentHP);
            _armature.animation.GotoAndPlayByProgress(_animations[7], 0, 1);
            StartCoroutine(WaitAnimationEnd());
        }
    }
    public void Death()
    {
        _effectsConteiner.gameObject.SetActive(false);
        _HPcontroller.Hide();
        OnDeth?.Invoke();
    }
    
    private IEnumerator WaitAnimationEnd()
    {
        while (_armature.animation.lastAnimationName == _animations[1])
        {
            if (_armature.animation.isCompleted)
                _armature.animation.GotoAndPlayByProgress(_animations[1]);
            yield return null;
        }
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
