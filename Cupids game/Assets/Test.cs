using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("MiniBoss"))
    //    {
    //        print("detected trigg");
    //        Destroy(other.gameObject);
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MiniBoss"))
        {
            print("detected");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("something");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            EnemyManager.enemyLeft--;
            Scoremanager.points++;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
