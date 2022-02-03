using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{


    // Scene switch control for level picking and scene load
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;

    }
}
