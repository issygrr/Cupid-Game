using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
    // Start is called before the first frame update
    // public Transform Playerpos;
   // public NavMeshAgent agent;
    // public float health;
    public float lookRadius = 10f;
    public Transform target;
    // Start is called before the first frame update
  
    public void Start()
    {
       // agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // health = 10;
    }
    public void Die()
    {
        
            Destroy(gameObject);
        
        if(OnEnemyKilled != null)
        {
            OnEnemyKilled();
            
            }
    }

    public void Attacked()
    {
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    public void Update()
    {
       // float distance = Vector3.Distance(target.position, transform.position);
       // if( distance <= lookRadius)
       // {
           // agent.SetDestination(target.position);
       // }
        //enemy.destination = Playerpos.position;

    }
}
