using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{ public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
    private bool hasCollided = false;
    private Enemy enemy;
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        {
            
            Destroy(collision.gameObject);
            EnemyManager.enemyLeft--;
        }
        if (OnEnemyKilled != null)
        {
            OnEnemyKilled();

        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCollided)
        {
            enemy.healthbar = 0;
            print("checked ;)");
        }
    }
}
