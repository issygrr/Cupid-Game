using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBall : MonoBehaviour
{ public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
    
    //private Enemy enemy;
    private Vector3 target;
    private float speed;
    public GameObject sphere1;
    public float dmg = 10f;
    public float range = 100f;
    public Camera fpscam;
    public float shootForce, upwardForce;
    public Transform attackPoint;
    public float spread;
   // public bool enemyDead;

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


   
    // Start is called before the first frame update
    void Start()
    {
        //enemyDead = false;
    }
    public void Shoot()
    {
        Ray ray = fpscam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); //Just a point far away from the player

        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Just add spread to last direction

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(sphere1, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;
        Destroy(currentBullet, 2f);
        if(hit.collider.gameObject.tag == ("Enemy"))
        {
            Destroy(hit.collider.gameObject);
            Destroy(currentBullet,1f);
            EnemyManager.enemyLeft--;
        }
        if (OnEnemyKilled != null)
        {
            OnEnemyKilled();

        }
        { 
    }
        
        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpscam.transform.up * upwardForce, ForceMode.Impulse);

        //if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        //{
        //     GameObject clone = Instantiate(sphere1, attackPoint.position, Quaternion.identity);
        //     clone.GetComponent<Rigidbody>().AddForce(transform.forward * 10);

        //     Destroy(clone, 2f);
        //     //print("shot");
        //     clone.transform.GetComponent<Rigidbody>().isKinematic = false;
        //     //clone.transform.GetComponent<PlayerBall>().
        //     //Destroy(clone.GetComponent<PlayerBall>());
        //     //if(hit.collider.tag == ("Enemy"))
        //     //{
        //     //    Destroy(hit.collider.gameObject);
        //     //}
        //     //Debug.DrawLine(transform.position, hit.point, Color.red);
        //     Debug.Log(hit.transform.name);
        //     //Enemy target = hit.transform.GetComponent<Enemy>();
        //     //if(target != null)
        //     //{
        //     //    target.healthbar = 0f;
        //     //}
        // }

    }
    //public void EnemyKill()
    //{
    //    if (enemyDead == true)
    //    {
    //       // enemy.healthbar = 0f;

    //        print("checked ;)");
    //    }
    //    else
    //    {
    //       // EnemyManager.enemyLeft++;
    //    }
    //}
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Shoot();
        }
           
     
    }
}
