using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IBattleble
{
    public int _maxHP => throw new System.NotImplementedException();

    public int _currentHP => throw new System.NotImplementedException();

    public List<Effect> _effects => throw new System.NotImplementedException();

    public bool _myTurn => throw new System.NotImplementedException();

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
        throw new System.NotImplementedException();
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
