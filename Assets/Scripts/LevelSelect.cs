using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelSelect : MonoBehaviour
{
    [SerializeField] private Sprite _spriteActive;
    [SerializeField] private Sprite _spriteInActive;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TextMeshPro _levelNumberText;

    private LevelData _level;

    public void Initialize(LevelData level,float intervalY, bool isActive)
    {
        _level = level;
        transform.position -= new Vector3(0, intervalY);
        _levelNumberText.text = _level.LvlNumber.ToString();
        if (isActive)
            _spriteRenderer.sprite = _spriteActive;
        else
            _spriteRenderer.sprite = _spriteInActive;
    }
}
