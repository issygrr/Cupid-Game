using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClouds : MonoBehaviour
{
    // Cloud variables
    public GameObject clouds;
    public Transform[] spawnPoints;



    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 13; i++)
        {
            GameObject clone = Instantiate(clouds, spawnPoints[i].transform.position, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
