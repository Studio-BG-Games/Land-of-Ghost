using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Level_", menuName = "Levels/new Level", order = 51)]
public class Levels: ScriptableObject
{
    [SerializeField] private int _lvlNumber;
    [SerializeField] private Scene _scene;
    [SerializeField] private string _description;
}