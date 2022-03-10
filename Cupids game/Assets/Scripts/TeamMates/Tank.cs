using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tank : MonoBehaviour
{

    // Variables for moving
    private GameObject[] allEnemies;

    public Transform closestEnemy;

    private GameObject closestEnemyGb;

    private Rigidbody closestEnemyRb;

    private NavMeshAgent closestEnemyNMA;

    private bool enemyContact;

    private float moveSpeed = 6f;

    // Tank shoot
    public GameObject ballPrefab;

    public Transform spawnPoint;

    private float timePrefab;
    private float startTime = 3f;

    private Rigidbody ballRb;

    public float strenghtBall = 20f;

    private int timeShoot = 0;

    // Start is called before the first frame update
    void Start()
    {

        closestEnemy = null;

        enemyContact = true;        

        timePrefab = startTime;

    }

    // Update is called once per frame
    void Update()
    {

        closestEnemy = FindNearestEnemy();

        closestEnemyGb = FindNearestEnemyGb();

        Movement();

    }

    // Found in google and youtube
    public Transform FindNearestEnemy()
    {

        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Transform trans = null;

        foreach(GameObject go in allEnemies)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                trans = go.transform;
            }
        }
        return trans;
        
    }

    public GameObject FindNearestEnemyGb()
    {

        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        GameObject objectGame = null;

        foreach (GameObject go in allEnemies)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                objectGame = go.gameObject;
            }
        }
        return objectGame;

    }


    public void Movement()
    {

        if (Vector3.Distance(transform.position, closestEnemy.position) > 3.5f)
        {
            // if bool is true // In start function add bool is true
            if (enemyContact)
            {
                transform.position = Vector3.MoveTowards(transform.position, closestEnemy.position, moveSpeed * Time.deltaTime);

                transform.LookAt(closestEnemy);
            }
        }
        else if (Vector3.Distance(transform.position, closestEnemy.position) <= 3.5f)
        {
           
            if (timeShoot != 4)
            {
                Stun();

                ShootAtTarget();

            }
            else if (timeShoot == 4)
            {

                enemyContact = true;

                timeShoot = 0;
               
            }
                            
        }

    }

    public void Stun()
    {

        closestEnemyRb = closestEnemyGb.GetComponent<Rigidbody>();

        closestEnemyRb.constraints = RigidbodyConstraints.FreezeAll;

        closestEnemyNMA = closestEnemyGb.GetComponent<NavMeshAgent>();

        closestEnemyNMA.isStopped = true;

        closestEnemyGb.GetComponent<Enemy>().enabled = false;

        enemyContact = false;

    }


    public void ShootAtTarget()
    {
        transform.LookAt(closestEnemy);

        if (timePrefab <= 0)
        {
            GameObject ballInstance = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);

            ballRb = ballInstance.GetComponent<Rigidbody>();

            ballRb.AddRelativeForce(transform.forward * strenghtBall, ForceMode.Impulse);

            timePrefab = startTime;

            timeShoot++;
        }
        else
        {
            timePrefab -= Time.deltaTime;
        }
    }
}
