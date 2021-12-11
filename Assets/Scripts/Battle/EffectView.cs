using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectView : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Effect _effect;
    public void Init(Effect effect)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _effect = effect;

    }
}
