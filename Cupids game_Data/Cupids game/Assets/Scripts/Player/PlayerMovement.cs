using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;
    public float speed = 5;
    public float gravity = 10.0f;

    // Start is called before the first frame update
    public void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * (speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody>().velocity = (Vector3.up * (speed));
           


        }
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        Move();
    }
}
