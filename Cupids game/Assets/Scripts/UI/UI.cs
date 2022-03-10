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
    
    public void Settings()
    {
        
        
            settings.SetActive(true);
        
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
