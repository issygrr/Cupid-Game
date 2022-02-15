using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    private Transform enemy;
    private Vector3 target;
    public float speed;
    public GameObject arrowBall;
    // [SerializeField]
    private Camera fpsCam;
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
    private Camera cam;
    PlayerBall playerBall;
    public float weaponRange = 50f;
    // Start is called before the first frame update
    void Start()
    {
        //if(cam == null)
        //{
        //    this.enabled = false;
        //}
        //fpsCam = GetComponentInParent<Camera>();
       // enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        //target = new Vector3(enemy.position.x, enemy.position.y, enemy.position.z);
    }

    // void OnCollisionEnter(Collision collision)
    //{
    //   if(arrowBall.GetComponent<SphereCollider>().tag == ("Enemy"))
    //    {

    //        Destroy(collision.gameObject);
    //    }
    //}

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the thing tagged enemy, not youself
            Destroy(collision.gameObject);

            // Could still destroy the bullet itself as well
            Destroy(gameObject);
        }

        if (OnEnemyKilled != null)
        {
            OnEnemyKilled();

        }
    }

    // Update is called once per frame
    void Update()
    {

        //if(Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    // RaycastHit hit;
        //    //  Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        //    playerBall.InstantiateTest();
        //    Debug.Assert(playerBall);
            
        //    //if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
        //    //{

        //    //}
        //        //Health();
        //    // Shoot();
        //}
       

    }
    void Shoot()
    {
        //RaycastHit _hit;
       // if(Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, arrowBall.transform, ))
        {

        }
    }

    //void InstantiateTest()
    //{
    //     Instantiate(arrowBall, transform.position, Quaternion.identity);
    //     //arrow.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
    //    transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    //    //Destroy(gameObject, 5f);
    //    print("shot");
    //}
   
}
