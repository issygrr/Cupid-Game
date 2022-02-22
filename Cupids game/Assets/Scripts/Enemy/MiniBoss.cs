using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MiniBoss : MonoBehaviour
{
    NavMeshAgent agent;
    
    public GameObject ballPrefab;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float healthbar = 100f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        timeBtwShots = startTimeBtwShots;
        gameObject.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Weapon"))
        {
            healthbar -= 50; 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Weapon"))
        {
            healthbar -= 50;
        }
    }
    void PathComplete()
    {
        //if the path has reached its stopping destination, shoot
        if (Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                Shoot();
                //  print("reached");
            }
        }

        // return false;
    }
    void Shoot()
    {
        // shooting between seconds to delay shots
        if (timeBtwShots <= 0)
        {
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    void Health()
    {
        if (healthbar == 0f)
        {

            Die();
        }
    }
    public void Die()
    {

        gameObject.SetActive(false);
        
    }
    // Update is called once per frame
    void Update()
    {
        PathComplete();
        Health();
    }
}
