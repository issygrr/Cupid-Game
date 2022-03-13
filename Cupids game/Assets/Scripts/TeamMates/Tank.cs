using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{

    // Variables for moving
    private GameObject[] allEnemies;

    private Transform closestEnemy;

    private GameObject closestEnemyGb;

    private Rigidbody closestEnemyRb;

    private NavMeshAgent closestEnemyNMA;

    private float moveSpeed = 6f;

    private float holdTime = 6f;

    private float holdPosition = 0f;

    // Tank shoot
    public GameObject ballPrefab;

    public Transform spawnPoint;

    private float timePrefab;
    private float startTime = 3f;

    private Rigidbody ballRb;

    private float strenghtBall = 10f;

    private int timeShoot = 0;

    // Slider to show the tank hold time
    public Image slider;

    // Start is called before the first frame update
    void Start()
    {

        closestEnemy = null;        

        timePrefab = startTime;

    }

    // Update is called once per frame
    void Update()
    {

        closestEnemy = FindNearestEnemy();

        closestEnemyGb = FindNearestEnemyGb();

        Movement();

    }

    
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

        if (Vector3.Distance(transform.position, closestEnemy.position) > 4f)
        {
            holdPosition -= Time.deltaTime;

            slider.fillAmount += Time.deltaTime * 0.072f;

            if (holdPosition <= 0f)
            {

                transform.position = Vector3.MoveTowards(transform.position, closestEnemy.position, moveSpeed * Time.deltaTime);

                closestEnemyGb.GetComponent<Enemy>().enabled = false;

                transform.LookAt(closestEnemy);

            }

        }
        else if (Vector3.Distance(transform.position, closestEnemy.position) <= 4f)
        {


            //enemyContact = false;

            if (timeShoot != 4)

            holdPosition = 15f;

            slider.fillAmount = 0;

            if (holdTime > 0f)

            {

                Stun();

                ShootAtTarget();

                holdTime -= Time.deltaTime;

            }
            else if (holdTime <= 0)
            {

                closestEnemyRb.constraints = RigidbodyConstraints.None;

                closestEnemyNMA.isStopped = false;

                holdTime = 6f;
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
