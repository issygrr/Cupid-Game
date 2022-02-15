using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{ public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
    private bool hasCollided = false;
    private Enemy enemy;
    private Vector3 target;
    private float speed;
    public GameObject sphere1;
    public float dmg = 10f;
    public float range = 100f;
    public Camera fpscam;

    //public void OnCollisionEnter(Collision collision)
    //{
    //    print("collided");
    //    if (collision.gameObject.tag == ("Enemy"))
    //    {
    //       // Destroy(Instantiate(gameObject.gameObject, transform.position, transform.rotation), 5f);
    //        Destroy(collision.gameObject);
    //        EnemyManager.enemyLeft--;
    //    }
    //    if (OnEnemyKilled != null)
    //    {
    //        OnEnemyKilled();

    //    }
        
    
    public void OnTriggerEnter(Collider other)
    {
        print("triggered");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Shoot()
    {
        RaycastHit hit;
       if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
       {
            GameObject clone = Instantiate(sphere1, fpscam.transform.position, Quaternion.LookRotation(hit.normal));
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * 10);

            Destroy(clone, 2f);
            //print("shot");
            clone.transform.GetComponent<Rigidbody>().isKinematic = false;
            //clone.transform.GetComponent<PlayerBall>().
            //Destroy(clone.GetComponent<PlayerBall>());
            //if(hit.collider.tag == ("Enemy"))
            //{
            //    Destroy(hit.collider.gameObject);
            //}
            //Debug.DrawLine(transform.position, hit.point, Color.red);
            Debug.Log(hit.transform.name);
            //Enemy target = hit.transform.GetComponent<Enemy>();
            //if(target != null)
            //{
            //    target.healthbar = 0f;
            //}
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Shoot();
        }
            if (hasCollided)
        {
            enemy.healthbar = 0;
            print("checked ;)");
        }
     
    }
}
