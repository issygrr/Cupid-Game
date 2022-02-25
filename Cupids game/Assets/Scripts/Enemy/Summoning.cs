using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Summoning : MonoBehaviour
{
   
    public float completionPoints;
    public float speed;
    public bool isDone;
    public bool isNotDone;
    public bool stillDoing;
    public float timeLeft = 10f;
    
    
    // Start is called before the first frame update
    void Start()
    {

        SliderTimer.started = false;
        
        completionPoints = 0;
       
        isDone = false;
        //isNotDone = true;
    }
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SliderTimer.started = true;
            //slider.gameObject.SetActive(true);
            timeLeft -= Time.deltaTime;
            //slider.value = timeLeft;
            stillDoing = true;
            if (timeLeft <= 0)
            {

               
                timeLeft = 0f;
            }
            print("check");
            
            
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        SliderTimer.started = false;
       
       
        isNotDone = true;
    }
    void SummonComplete()
    {
        if(timeLeft == 0)
        {
            isDone = true;
            isNotDone = false;
        }
        if(timeLeft > 0)
        {
            stillDoing = true;
        }
       if(timeLeft != 0)
        {
            
            isDone = false;
        }
    }
    
    void CalculateDone()
    {
      
        if(stillDoing == true)
        {
            //slider.gameObject.SetActive(true);
        }
        if (isNotDone == true && timeLeft == 0)
        {

            if (isDone == true)
            {
                DestroyCircle();
                SpawnSummoning.circlesLeft--;
                // gameObject.SetActive(false);
            }
            //slider.gameObject.SetActive(false);
        }
    }
    void DestroyCircle()
    {
        Destroy(gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        CalculateDone();
        SummonComplete();
    }
}
