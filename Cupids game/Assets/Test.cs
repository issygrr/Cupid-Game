using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Transform enemy;
    public Rigidbody rb;
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("MiniBoss"))
    //    {
    //        print("detected trigg");
    //        Destroy(other.gameObject);
    //    }
    //}
    void OnCollisionEnter(Collision collision)
    {
        var originalScale = transform.localScale;
       // var originalRotation = transform.localRotation;
        var originalPosition = transform.position;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            print("detected");

            transform.SetParent(collision.transform, true);
           // rb.isKinematic = true;
           // rb.velocity = Vector3.zero;
            //rb.angularVelocity = Vector3.zero;
            //transform.localScale = originalScale;
            //transform.localRotation = originalRotation;
            //transform.position = originalPosition;



            Destroy(rb);




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
