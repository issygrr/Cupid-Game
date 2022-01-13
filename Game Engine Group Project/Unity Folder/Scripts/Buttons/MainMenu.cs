using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onStart()
    {
        //loads up following scene when executed.
        SceneManager.LoadScene("Scene1");
    }

    public void onSettings()
    {
        //loads up following scene when executed.
        SceneManager.LoadScene("Settings");
    }

    public void onBack()
    {
        //loads up following scene when executed.
        SceneManager.LoadScene("MainMenu");
    }

    public void CloseGame()
    {
        //for testing
        //Debug.Log("Closing");

        //closes the game
        Application.Quit();
    }
}
