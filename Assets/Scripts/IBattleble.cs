
using System.Collections.Generic;

public interface IBattleble
{
    int _maxHP { get; }
    int _currentHP { get; }
    List<Effect> _effects { get; }
    bool _myTurn { get; }
    int DealDamage();
    void TakeDamage(int amount);
    void SetEffect(Effect effect);
    void ClearEffect(Effect effect);
    void Death();
}