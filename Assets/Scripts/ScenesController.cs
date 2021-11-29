using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{

    public void Quit()
    {
        Application.Quit();
    }
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
 