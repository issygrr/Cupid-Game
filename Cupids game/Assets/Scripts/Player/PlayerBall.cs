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
    //public float dmg = 25f;
    public float range = 100f;
    public Camera fpscam;
    public float shootForce, upwardForce;
    public Transform attackPoint;
    public float spread;
    public float damage = 25f;
    public float impactForce = 30f;
    public float health = 50f;
    private bool death;
    public Rigidbody rb;
    public GameObject explosion;
    public int explosionDamage;
    public float explosionRange;
    public float explosionForce;
    public bool explodeOnTouch = true;
    int collisions;
    public LayerMask whatIsEnemies;
    public Transform enemy;
    float distance;
    public GameObject one;
    public GameObject two;


    // public bool enemyDead;

    //public void OnCollisionEnter(Collision collision)
    //{
    //    print("collided");
    //    if (collision.gameObject.tag == ("Enemy"))
    //    {
    //        // Destroy(Instantiate(gameObject.gameObject, transform.position, transform.rotation), 5f);
    //        Destroy(collision.gameObject);
    //        EnemyManager.enemyLeft--;
    //    }
    //    if (OnEnemyKilled != null)
    //    {
    //        OnEnemyKilled();

    //    }

    //}

    // Start is called before the first frame update
    void Start()
    {
        death = false;
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

        //Instantiate bullet/ projectile
        GameObject currentBullet = Instantiate(sphere1, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;
        Destroy(currentBullet, 7f);

        //if (hit.collider.gameObject.tag == ("Enemy"))
        //{


        //        //Destroy(hit.collider.gameObject);
        //        death = false;
        //        // Enemy target = hit.transform.GetComponent<Enemy>();
        //        // EnemyManager manager = hit.transform.GetComponent<EnemyManager>();
        //        //if (hit.collider.gameObject != null)
        //        //{
        //        //    TakeDmg(damage);
        //        //}
        //        //else
        //        //{
        //        //    death = false;
        //        //    EnemyManager.enemyLeft++;
        //        //}

        //        //if (death == true)
        //        //{
        //        //    Destroy(hit.collider.gameObject);
        //        //    EnemyManager.enemyLeft--;
        //        //    Scoremanager.points++;
        //        //}
        //        //if (OnEnemyKilled != null)
        //        //{
        //        //    OnEnemyKilled();

        //        //}




        //    // if(hit.rigidbody != null)
        //    // {
        //    //     hit.rigidbody.AddForce(-hit.normal);
        //    // }
        //    //if (Enemy.healthbar == 0)
        //    //{
        //    //    Destroy(hit.collider.gameObject);
        //    //    EnemyManager.enemyLeft--;
        //    //}

        //    Destroy(currentBullet, 1f);
        //    //EnemyManager.enemyLeft--;


        //}



        ////Add forces to bullet
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
    private void Explode()
    {
        //Instantiate explosion
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        //Check for enemies 
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
        for (int i = 0; i < enemies.Length; i++)
        {
            //Get component of enemy and call Take Damage

            //Just an example!
            ///enemies[i].GetComponent<ShootingAi>().TakeDamage(explosionDamage);

            //Add explosion force (if enemy has a rigidbody)
            if (enemies[i].GetComponent<Rigidbody>())
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRange);
        }

        //Add a little delay, just to make sure everything works fine
        Invoke("Delay", 0.05f);
    }
    private void Delay()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Don't count collisions with other bullets
        if (collision.collider.CompareTag("Weapon")) return;
        if (collision.collider.CompareTag("Player")) return;

        //Count up collisions
        collisions++;

        //Explode if bullet hits an enemy directly and explodeOnTouch is activated
        if (collision.collider.CompareTag("Enemy") && explodeOnTouch) Explode();
    }
    public void TakeDmg(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            death = true;

        }
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
        float distance = Vector3.Distance(one.transform.position, two.transform.position);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

        Debug.DrawLine(transform.position, fpscam.transform.position);
    }
}
