using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject gameOver;
    public Transform cam;
    public UI uI;
    
    public static float healthbar = 60f;

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
            PlayerHealth.numbOfHearts = 0;
        }
    }



    public void GameOver()
    {
        gameObject.SetActive(false);
        gameOver.SetActive(true);
        cam.parent = null;
        Time.timeScale = 0.1f;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Health()
    {
        if (healthbar == 0)
        {
            PlayerHealth.numbOfHearts = 0;

            healthbar = 60f;

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
