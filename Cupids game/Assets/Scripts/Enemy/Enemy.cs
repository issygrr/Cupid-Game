using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
   
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
    NavMeshAgent agent;
    
    public GameObject ballPrefab;
    private float timeBtwShots;
    public float startTimeBtwShots;
    
    public float enemyhealth = 100f;
    public float maxHealth = 100f;
     static public float healthbar = 100f;
    public Slider slider;
    public GameObject healthBarUI;
  
    public float range = 10f;
  
    public void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
        timeBtwShots = startTimeBtwShots;
        enemyhealth = maxHealth;
        slider.value = CalculateHealth();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            print("something");
            TakeDmg(25);
            slider.value -= 0.25f;
            
            
        }
    }
    float CalculateHealth()
    {
        return enemyhealth / maxHealth;   
    }
    void PathComplete()
    {
        //if the path has reached its stopping destination, shoot
        if (Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                Shoot();
              
            }
        }

       
    }
    public void TakeDmg(float amount)
    {
        enemyhealth -= amount;
        if(enemyhealth == 0f)
        {
            slider.value = 0;
            EnemyManager.enemyLeft--;
            Scoremanager.points++;
            Die();
            
        }
    }
    void Health()
    {
        if (enemyhealth == 0f)
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
  
    public void Update()
    {
        if(enemyhealth < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        PathComplete();
        Health();
       
    }
}
