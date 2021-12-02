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

    public LevelData Level { get; private set; }
    public void Initialize(LevelData level,float intervalY, bool isActive)
    {
        Level = level;
        transform.position -= new Vector3(0, intervalY);
        _levelNumberText.text = Level.LvlNumber.ToString();
        _spriteRenderer.sprite = _spriteActive;
    }
}
