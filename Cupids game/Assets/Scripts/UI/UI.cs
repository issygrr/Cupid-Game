using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject settings;
    public GameObject levelpicker;
   


    // UI manager for buttons
    public void Start()
    {
        //hide UI panels
        levelpicker.SetActive(false);
        settings.SetActive(false);
       

    }
    private void Update()
    {
        Settings();
    }

    public void Settings()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settings.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(Input.GetButtonDown("Back"))
        {
            settings.SetActive(false);
            Time.timeScale = 1f;
        }
        


    }
    public void LevelPick()
    {
        levelpicker.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Back()
    {
        levelpicker.SetActive(false);
        settings.SetActive(false);
        Time.timeScale = 1f;
    }

    //public void GameOver()
    //{
    //    Player.healthBar = 0
    //    gameObject.SetActive(false);
    //    gameOver.SetActive(true);
    //    cam.parent = null;
    //    Time.timeScale = 0.1f;
    //    Cursor.lockState = CursorLockMode.None;
    //}
    
}
