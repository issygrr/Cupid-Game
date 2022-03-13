using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClouds : MonoBehaviour
{
    // Cloud variables
    public GameObject clouds;
    public int NumberOfClouds;
    public Transform[] spawnPoints;
    

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < NumberOfClouds; i++)
        {
            GameObject clone = Instantiate(clouds, spawnPoints[i].transform.position, Quaternion.Euler(new Vector3(0, Random.Range(0f, 360f), 0)));

            float randomNum = Random.Range(200, 370);

            Vector3 randomSize = new Vector3(randomNum, randomNum, randomNum);

            clone.transform.localScale = randomSize;
        }

    }

}
