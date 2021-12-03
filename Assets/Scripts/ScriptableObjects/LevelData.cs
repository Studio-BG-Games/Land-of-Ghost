using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level_", menuName = "Levels/new Level", order = 51)]
public class LevelData: ScriptableObject
{
    [SerializeField] private int _lvlNumber;
    [SerializeField] private string _description;
    [SerializeField] private string _conversationName;
    [SerializeField] private bool _isComplete;
    [SerializeField] private List<Enemy> _enemies;
    private LevelData _levelDataOrigin;

    public int LvlNumber => _lvlNumber;
    public string Description => _description;
    public string ConversationName => _conversationName;
    public bool IsComplete => _isComplete;
    public List<Enemy> Enemies => _enemies;

    public void Complete()
    {
        if (_levelDataOrigin != null)
            _levelDataOrigin.Complete();
        _isComplete = true;
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