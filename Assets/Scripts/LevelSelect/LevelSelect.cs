using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelSelect : MonoBehaviour
{
    [SerializeField] private Sprite _spriteActive;
    [SerializeField] private SpriteRenderer _imageInBuble;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TextMeshPro _text;

    private TweenMover _mover;
    public LevelData Level { get; private set; }
    public void Initialize(LevelData level,float intervalY, bool isActive)
    {
        Level = level;
        transform.position -= new Vector3(0, intervalY);
        _spriteRenderer.sprite = _spriteActive;
        _imageInBuble.sprite = Level.ImageInBuble;
        _mover = GetComponent<TweenMover>();
        _text.text = level.TextOnLevelSelect;
    }
    public void SetCurrent(bool curernt)
    {
        if(curernt)
            _mover.Scale(1.5f);
        else
            _mover.Scale(1);
    }
}
