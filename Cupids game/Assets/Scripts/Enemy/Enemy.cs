using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
   // public PlayerBall playerBall;
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
    NavMeshAgent agent;
    Vector3 forwardVector = Vector3.forward;
    public GameObject ballPrefab;
    private float timeBtwShots;
    public float startTimeBtwShots;
    // Start is called before the first frame update
    // public Transform Playerpos;
    // public NavMeshAgent agent;
     public float healthbar = 100f;
    //public Transform hitCheck;
  //  public GameObject playerWeapon;
    public float range = 10f;
    // public float lookRadius = 10f;
    // public Transform target;
    // Start is called before the first frame update
    //void OnTriggerEnter(Collider other)
    //{

    //    if (other.gameObject.tag == ("Weapon"))
    //    {
    //        healthbar -= 100;
    //        print("enemy hit");
    //    }
    //}
    //public void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == ("Weapon"))
    //    {
    //        healthbar -= 100;
    //        print("enemy hit");
    //    }
    //}
    public void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        healthbar = 100f;
        timeBtwShots = startTimeBtwShots;
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
    void Health()
    {
        if (healthbar == 0f)
        {

            Die();
        }
    }
    public void Die()
    {

        Destroy(gameObject);
        if(OnEnemyKilled != null)
        {
            OnEnemyKilled();
            
            }
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
  
    //private void OnDrawGizmosSelected()
    //{
    //   // Gizmos.color = Color.red;
    //   // Gizmos.DrawWireSphere(transform.position, lookRadius);
    //}
    public void Update()
    {
        //RaycastHit hit; 
        //    if(Physics.Raycast(hitCheck.transform.position, forwardVector, out hit, range))
        //{
        //    Destroy(gameObject);
        //}

        //if (hit.collider != null && hit.collider.tag == ("Weapon"))
        //{

        //    Destroy(gameObject);

        //}
        // float distance = Vector3.Distance(target.position, transform.position);
        // if( distance <= lookRadius)
        // {
        // agent.SetDestination(target.position);
        // }
        //enemy.destination = Playerpos.position;
        PathComplete();
        Health();
    }
}
