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
    public Action OnDeth;

    public int CurrentHP => _currentHP;
    public List<Effect> _effects => throw new System.NotImplementedException();
    public bool _myTurn => throw new System.NotImplementedException();
    public int MaxHP => _maxHP;

    private Dictionary<int, string> _animations = new Dictionary<int, string>(7);
    private void Start()
    {
        _animations.Add(1, "stan"); // idle
        _animations.Add(2, "stan0");
        _animations.Add(3, "atack"); //attacks
        _animations.Add(4, "atack0");
        _animations.Add(5, "atack1");
        _animations.Add(6, "atack4");
        _animations.Add(7, "demeg"); // take dmg

        _HPcontroller.OnHealthChange(_maxHP,_currentHP);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            DealDamage();
        if (Input.GetKeyDown(KeyCode.D))
            Death();
        if (Input.GetKeyDown(KeyCode.S))
            TakeDamage(1);
    }
    public void ClearEffect(Effect effect)
    {
        throw new System.NotImplementedException();
    }

    public int DealDamage()
    {
        _armature.animation.GotoAndPlayByProgress(_animations[Random.Range(3,6)], 0, 1);
        StartCoroutine(WaitAnimationEnd());
        return 1;
    }

    public void Death()
    {
        _effectsConteiner.gameObject.SetActive(false);
        _armature.gameObject.SetActive(false);
        OnDeth?.Invoke();
    }

    public void SetEffect(Effect effect)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        _armature.animation.GotoAndPlayByProgress(_animations[7], 0, 1);
        StartCoroutine(WaitAnimationEnd());
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
}
