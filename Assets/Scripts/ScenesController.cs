using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers; 

public class ScenesController : MonoBehaviour
{
    [SerializeField] private GameSaver _gameSaver;
    private void Start()
    {
#if (!UNITY_EDITOR)
        _gameSaver.Load();        
#endif
    }
    public void Quit()
    {
#if (!UNITY_EDITOR)
        _gameSaver.Save();
#endif
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
 