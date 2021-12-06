
using System.Collections.Generic;

public interface IBattleble
{
    int MaxHP { get; }
    int CurrentHP { get; }
    List<Effect> _effects { get; }
    bool _myTurn { get; }
    int DealDamage();
    void TakeDamage(int amount);
    void SetEffect(Effect effect);
    void ClearEffect(Effect effect);
    void Death();
}