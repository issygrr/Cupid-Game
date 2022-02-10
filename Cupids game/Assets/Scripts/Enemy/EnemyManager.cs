using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawningPoints;
    public GameObject enemyPrefab;
    public static int enemyLeft;
    // Start is called before the first frame update
    void Start()
    {
        enemyLeft = 1;
        InstantateEnemy();
        //enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
   void OnEnable()
    {
        Enemy.OnEnemyKilled += SpawnNewEnemy;
        Weapon.OnEnemyKilled += SpawnNewEnemy;
    }

    public void Update()
    {
        SpawnNewEnemy();
    }
    void InstantateEnemy()
    {
        int randomNumber = Mathf.RoundToInt(Random.Range(0f, spawningPoints.Length - 1));
        Instantiate(enemyPrefab, spawningPoints[randomNumber].transform.position, Quaternion.identity);
    }

    void SpawnNewEnemy()
    {
        if (enemyLeft == 0)
        {
            InstantateEnemy();
            enemyLeft++;
        }
    }
}
