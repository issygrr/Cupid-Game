using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerBall : MonoBehaviour

{
    
    public GameObject sphere1;
    
    public float range = 100f;
    public Camera fpscam;
    public float shootForce, upwardForce;
    public Transform attackPoint;
    public float spread;
    public float damage = 10f;
    public float impactForce = 30f;
    public float health = 50f;
     GameObject currentOne;
    
    public Rigidbody rb;
    public GameObject explosion;
    public int explosionDamage;
    public float explosionRange;
    public float explosionForce;
    public bool explodeOnTouch = true;
    public bool shotDone;
    public float pos;
    public GameObject crosshair;
   
    public LayerMask whatIsEnemies;
    public Transform enemy;
    
    public GameObject one;
    public GameObject two;
    public Transform aimPoint;
    Vector3 defaultPos;

    public bool DelaySet;

    void Start()
    {
        defaultPos = attackPoint.transform.localPosition;
        DelaySet = false;
        shotDone = false;
        crosshair.SetActive(false);
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

        ////Calculate spread
        //float x = Random.Range(-spread, spread);
        //float y = Random.Range(-spread, spread);

        ////Calculate new direction with spread
        //Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Just add spread to last direction

        //Instantiate bullet/ projectile

        GameObject currentBullet = Instantiate(sphere1, attackPoint.position, Quaternion.identity);
        //currentBullet.transform.rotation = Quaternion.Euler(0f, 0f, 0);
        
        shotDone = true;//store instantiated bullet in currentBullet
        //Rotate bullet to shoot direction
       // currentBullet.transform.forward = directionWithoutSpread.normalized;
        //var force = attackPoint.TransformDirection(Vector3.forward * shootForce);
        //currentBullet.transform.forward = force;
        Destroy(currentBullet, 4f);

        currentOne = currentBullet;
        //////Add forces to bullet
        //currentBullet.GetComponent<Rigidbody>().AddForce(attackPoint.transform.forward * shootForce, ForceMode.Impulse);
        //currentBullet.GetComponent<Rigidbody>().AddForce(fpscam.transform.up * upwardForce, ForceMode.Impulse);

    }
    void InstantiateArrow()
    {

        GameObject currentBullet = Instantiate(sphere1, attackPoint.transform.position, Quaternion.identity);
        currentOne = currentBullet;
        Destroy(currentBullet, 4f);
    }
   public void ArrowFly()
    {
        if(shotDone == true) 
        {
            Ray ray = fpscam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            
            Vector3 targetPoint;
            
                targetPoint = ray.GetPoint(10); //Just a point far away from the player

            //Calculate direction from attackPoint to targetPoint
            Vector3 directionWithoutSpread = targetPoint - fpscam.transform.position;
            crosshair.SetActive(false);
           // currentOne.transform.forward = directionWithoutSpread.normalized;
            //currentOne.transform.parent = null;
            fpscam.fieldOfView = 43f;
            Rigidbody rb = currentOne.GetComponent<Rigidbody>();
            rb.velocity = fpscam.transform.forward * shootForce;
            //attackPoint.transform.position = defaultPos;
            currentOne.GetComponent<Rigidbody>().AddForce(fpscam.transform.up * upwardForce, ForceMode.Impulse);
           
            currentOne.GetComponent<Rigidbody>().AddForce(directionWithoutSpread * shootForce, ForceMode.Impulse);
           // currentOne.transform.rotation = Quaternion.Euler(0f, 180f, 0);
        }
        
    }
    public void Aim()
    {
        crosshair.SetActive(true);
        //InstantiateArrow();
        //currentOne.transform.parent = aimPoint.transform;
        fpscam.fieldOfView = 30;
        //attackPoint.transform.position = aimPoint.position;
    }
    IEnumerator DelayShooting()
    {

        InstantiateArrow();

        DelaySet = true;

        yield return new WaitForSeconds(1f);

        DelaySet = false;

    }


    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shotDone = true;
            if (DelaySet == false)
            {
                StartCoroutine(DelayShooting());
                ArrowFly();
            }
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Aim();
        }
        else
        {

        }

        
    }
}
