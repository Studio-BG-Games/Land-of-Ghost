using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level_", menuName = "Levels/new Level", order = 51)]
public class LevelData: ScriptableObject
{
    [SerializeField] private int _lvlNumber;
    [SerializeField] private string _description;
    [SerializeField] private string _conversationName;
    [SerializeField] private string _textOnLevelSelect;
    [SerializeField] private bool _isComplete;
    [SerializeField] private bool _isActive = true;
    [SerializeField] private bool _isQuest;
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private Sprite _imageInBuble;
    private LevelData _levelDataOrigin;

    public int LvlNumber => _lvlNumber;
    public string Description => _description;
    public string ConversationName => _conversationName;
    public string TextOnLevelSelect => _textOnLevelSelect;
    public bool IsComplete => _isComplete;
    public bool IsActive => _isActive;
    public bool IsQuest => _isQuest;
    public List<Enemy> Enemies => _enemies;
    public Sprite ImageInBuble => _imageInBuble;

    public void Complete(bool isComplete = true)
    {
        if (_levelDataOrigin != null)
            _levelDataOrigin.Complete();
        _isComplete = isComplete;
    }
    public void Activate(bool isActivate = true)
    {
        _isActive = isActivate;
    }
    public void SetLevelOrigin(LevelData levelDataOrigin)
    {
        _lvlNumber = levelDataOrigin.LvlNumber;
        _conversationName = levelDataOrigin.ConversationName;
        _isComplete = levelDataOrigin.IsComplete;
        _enemies = levelDataOrigin.Enemies;
        _levelDataOrigin = levelDataOrigin;
    }
}