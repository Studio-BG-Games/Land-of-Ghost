using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    [SerializeField] private GameSaver _gameSaver;
    private void Awake()
    {
#if (!UNITY_EDITOR)
        _gameSaver.Load();
#endif
    } 
    public void Quit()
    {
        _gameSaver.Save();
        Application.Quit();
    }
    public void GoToScene(string sceneName)
    {
#if (!UNITY_EDITOR)
        _gameSaver.Save();
#endif
        SceneManager.LoadScene(sceneName);
    }
}
 