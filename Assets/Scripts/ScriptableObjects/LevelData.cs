using UnityEngine;

[CreateAssetMenu(fileName = "Level_", menuName = "Levels/new Level", order = 51)]
public class LevelData: ScriptableObject
{
    [SerializeField] private int _lvlNumber;
    [SerializeField] private string _sceneName;
    [SerializeField] private string _description;
    [SerializeField] private bool _isComplete;

    public int LvlNumber => _lvlNumber;
    public string SceneName => _sceneName;
    public string Description => _description;
    public bool IsComplete => _isComplete;

    public void Complete()
    {
        _isComplete = true;
    }
}