using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;


public class Scoremanager : MonoBehaviour
{
    public static int points;
    public int score;
    //private EnemyManager enemy;
    // Start is called before the first frame update
    void Start()
    {

        points = 0;
    }
    public void AddPoints()
    {
        
        for (int i = 0; i < 0; i = 10)
        {
            points = i;
        }
        //++points;
       
    }
    public void OnGUI()
    {
        GUI.contentColor = Color.black;
        GUI.Box(new Rect(5, 5, 100, 25), "Enemy Killed: " + points);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
