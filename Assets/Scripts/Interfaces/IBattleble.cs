
using System.Collections.Generic;

public interface IBattleble
{
    int MaxHP { get; }
    int CurrentHP { get; }
    List<Effect> Effects { get; }
    bool MyTurn { get; }
    void DealDamage();
    void TakeDamage(int amount, bool animate = true);
    void SetEffect(Effect effect);
    void ClearEffect(Effect effect);
    void Death();
}