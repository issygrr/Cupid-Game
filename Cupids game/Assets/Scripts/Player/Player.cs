using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
    public GameObject gameOver;
    public Transform cam;
    
    private float healthbar = 60f;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Enemy"))
        {
            healthbar -=10;
            PlayerHealth.numbOfHearts--;
        }
        if(other.gameObject.tag == ("Bounds"))
        {
            gameObject.SetActive(false);
            GameOver();
            
        }
    }
    

     
    public void GameOver()
    {
        gameObject.SetActive(false);
        gameOver.SetActive(true);
        cam.parent = null;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Health()
    {
        if(healthbar == 0)
        {
            GameOver();
           
        }
        //when enemy attacks - health
    }
    void Start()
    {
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
       
        Health();
        //GameOver();
    }
}
