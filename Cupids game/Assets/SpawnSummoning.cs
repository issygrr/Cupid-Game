using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnSummoning : MonoBehaviour
{
    public GameObject summoningCircle;
    public Transform[] spawningPoints;
    public static int circlesLeft;
    public float pip;
    public int points;
    public GameObject miniboss;
    
    //public  Slider slider;
   // public float timeLeft = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
        //miniboss.SetActive(false);
        InstantateCircles();
        circlesLeft = 11;
    }
    void InstantateCircles()
    {
        int randomNumber = Mathf.RoundToInt(Random.Range(0f, spawningPoints.Length));
        for (int i = 0; i < 11; i++)
        {
            
            GameObject clone = Instantiate(summoningCircle, spawningPoints[i].transform.position, Quaternion.identity);
        }
        
        Debug.Log(points);
    }
    //public void SliderTimer()
    //{
    //    //slider.gameObject.SetActive(true);
    //    //Instantiate(slider, slider.transform.position, Quaternion.identity);
    //    timeLeft -= Time.deltaTime;
    //    slider.value = timeLeft;
        
    //    if (timeLeft <= 0)
    //    {

            
    //        timeLeft = 0f;
    //    } 
    //}

    public void SummonLeft()
    {
        if (circlesLeft == 0)
        {
            miniboss.SetActive(true);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        SummonLeft();
    }
}
