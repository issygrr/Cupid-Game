using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   
    public Transform[] spawningPoints;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnNewEnemy();
        //enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    void SpawnNewEnemy()
    {
        Instantiate(enemyPrefab, spawningPoints[0].transform.position, Quaternion.identity);
    }
}
