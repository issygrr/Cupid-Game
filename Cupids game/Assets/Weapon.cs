using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Transform enemy;
    private Vector3 target;
    public float speed;
    public GameObject arrowBall;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        target = new Vector3(enemy.position.x, enemy.position.y, enemy.position.z);
    }
     void OnCollisionEnter(Collision collision)
    {
        if(arrowBall.GetComponent<SphereCollider>().tag == ("Enemy"))
        {

            Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameObject arrow =Instantiate(arrowBall, transform.position, Quaternion.identity) as GameObject;
            // arrow.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyBall();
        }
        void DestroyBall()
        {
            Destroy(gameObject);
        }
    }
}
