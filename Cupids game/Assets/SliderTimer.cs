using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{
    public float timeLeft = 10f;
    public Slider slider;
    public static bool started;
    public static bool notStarted;
    // Start is called before the first frame update
    void Start()
    {
        started = false;
    }
    public void STimer()
    {
        if (started == true)
        {

            timeLeft -= Time.deltaTime;
            slider.value = timeLeft;

        }
        else if(started == false)
        {
            
            timeLeft = 10;
            slider.value = 0f;
            
        }        
        else if (timeLeft <= 0)
        {


            timeLeft = 0f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        STimer();
    }
}
