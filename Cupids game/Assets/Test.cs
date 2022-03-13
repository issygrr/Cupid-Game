using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Transform enemy;
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
       
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("detected");
            transform.parent = collision.transform;
            transform.localPosition = Vector3.zero;
            
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //gameObject.GetComponent<MeshCollider>().isTrigger = true;

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
