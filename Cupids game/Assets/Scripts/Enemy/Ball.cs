using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Transform player;
    private Vector3 target;
    public float speed;
    public float gravity;
    private Rigidbody rb;
    public float gMoon = -10f;  //gravity on the moon.

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y, player.position.z);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ShootPos();
    }

    void FixedUpdate()
    {
       // rb.AddForce(new Vector3(0, -1.0f, 0) * rb.mass * gMoon);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyBall();
        }
    }
    void DestroyBall()
    {
        Destroy(gameObject);
    }
    void ShootPos()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        
            //Physics.gravity = new Vector3(0, -1.0F, 0);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyBall();
        }
    }

}
