using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public static int numbOfHearts;
    public Image[] hearts;
    public Sprite empty;
    public Sprite fullHearts;
    // Start is called before the first frame update
    void Start()
    {
        numbOfHearts = 5;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numbOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
            
        }
    }
}
