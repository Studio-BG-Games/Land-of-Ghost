using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    [SerializeField] private GameSaver _gameSaver;
    private void Awake()
    {
        _gameSaver.Load(); 
    } 
    public void Quit()
    {
        _gameSaver.Save();
        Application.Quit();
    }
    public void GoToScene(string sceneName)
    {
        _gameSaver.Save();
        SceneManager.LoadScene(sceneName);
    }
}
 